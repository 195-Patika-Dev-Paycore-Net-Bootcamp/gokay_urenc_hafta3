using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.API.Abstract;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Abstract;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers
{
    // Diğer controller'lar buradan kalıtım alır.
    // Bu controller ise sisteme ait olan ControllerBase sınıfından kalıtım alır.
    // Bu controller bir köprü görevi görmektedir. NonAction bir metod olan GetById metoduna sahiptir.
    // TEntity, CoreEntity sınıfından kalıtım almış bir sınıf olmak zorundadır.
    // TSession, ICoreSession'ı generic operatörünün ilk değerine yazılan tipten implemente etmiş bir sınıf olmak zorundadır.
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController<TEntity, TSession> : ControllerBase, ICoreController<TEntity>
        where TEntity : CoreEntity
        where TSession : ICoreSession<TEntity>
    {
        private readonly TSession _session;

        // Gerekli kurucu metod yazılır. Generic olarak belirlenen session tipindeki nesnenin bağımlılığı eklenir.
        public CoreController(TSession session)
        {
            _session = session;
        }

        // Diğer action metodlarında her seferinde id bilgisine ihtiyaç olduğunda generic olarak belirlenmiş session
        // tipi üzerinden id araması yapmaktansa tek seferde bir NonAction metodda bu arama ve validasyonlar yapılır.
        [NonAction]
        public async Task<ActionResult<TEntity>> GetById(long? id)
        {
            if (id == null) // Eğer bir id gönderilmediyse "Geçersiz istek" hatası döndürülür.
                return BadRequest();

            var entity = await _session.GetById((long)id); // Id'ye göre session nesnesi üzerinden veri araması yapılır.

            if (entity == null) // Eğer bir veri kaydı bulunamadıysa "Geçersiz istek" hatası döndürülür.
                return NotFound();

            return entity; // Tüm validasyonlardan geçmesi durumunda ise bulunan veri kaydı döndürülür.
        }
    }
}