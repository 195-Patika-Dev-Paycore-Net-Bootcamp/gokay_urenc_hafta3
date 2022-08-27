using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.API.Abstract;
using PayCoreClassWork3.WebAPI.Core.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers
{
    // Diğer controller'lar buradan kalıtım alır.
    // Bu controller ise sisteme ait olan ControllerBase sınıfından kalıtım alır.
    // Bu controller bir köprü görevi görmektedir. NonAction bir metod olan GetById metoduna sahiptir.
    // TEntity, CoreEntity sınıfından kalıtım almış bir sınıf olmak zorundadır.
    // TService, IService'ın generic operatörünün değerine yazılan tipten implemente etmiş bir sınıf olmak zorundadır.
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController<TEntity, TService> : ControllerBase, ICoreController<TEntity>
        where TEntity : CoreEntity
        where TService : IService<TEntity>
    {
        private readonly TService _service;

        // Gerekli kurucu metod yazılır. Generic olarak belirlenen servis tipindeki nesnenin bağımlılığı eklenir.
        public CoreController(TService service)
        {
            _service = service;
        }

        // Diğer action metodlarında her seferinde id bilgisine ihtiyaç olduğunda generic olarak belirlenmiş servis
        // tipi üzerinden id araması yapmaktansa tek seferde bir NonAction metodda bu arama ve validasyonlar yapılır.
        [NonAction]
        public async Task<ActionResult<TEntity>> GetById(long? id)
        {
            if (id == null) // Eğer bir id gönderilmediyse "Geçersiz istek" hatası döndürülür.
                return BadRequest();

            var entity = await _service.GetById((long)id); // Id'ye göre servis nesnesi üzerinden veri araması yapılır.

            if (entity == null) // Eğer bir veri kaydı bulunamadıysa "Geçersiz istek" hatası döndürülür.
                return NotFound();

            return entity; // Tüm validasyonlardan geçmesi durumunda ise bulunan veri kaydı döndürülür.
        }
    }
}