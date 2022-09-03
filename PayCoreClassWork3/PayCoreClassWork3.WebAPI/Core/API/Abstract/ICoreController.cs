using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.Dto.Abstract;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Core.API.Abstract
{
    // CoreController bu interface'i implemente eder.
    // Ortak action metodların yer alacağı interface'dir.
    // Generic operatörünün içerisinde belirlenecek tip CoreEntity'den kalıtım almış bir tip zorundadır.
    public interface ICoreController<TEntity, TDto>
        where TEntity : CoreEntity
        where TDto : ICoreDto
    {
        Task<List<TEntity>> GetAll(); // Tüm kayıtları listeleme.
        Task<ActionResult<TEntity>> GetById(long? id); // Id'ye göre tek bir kayıt getirme.
        Task<ActionResult> Add([FromBody] TDto dto); // Yeni bir kayıt ekleme.
        Task<ActionResult> Update(long? id, [FromBody] TDto dto); // Mevcut bir kaydı güncelleme.
        Task<ActionResult> Delete(long? id); // Mevcut bir kaydı silme.
    }
}