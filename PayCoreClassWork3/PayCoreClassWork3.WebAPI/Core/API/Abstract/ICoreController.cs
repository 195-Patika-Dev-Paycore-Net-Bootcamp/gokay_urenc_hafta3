using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;

namespace PayCoreClassWork3.WebAPI.Core.API.Abstract
{
    // CoreController bu interface'i implemente eder.
    // Ortak NonAction metodların yer alacağı interface'dir.
    // Generic operatörünün içerisinde belirlenecek tip CoreEntity'den kalıtım almış bir tip zorundadır.
    public interface ICoreController<TEntity> where TEntity : CoreEntity
    {
        Task<ActionResult<TEntity>> GetById(long? id); // NonAction olarak işaretlenecek ve tek sefer kullanılacak olan id'ye göre arama metodu.
    }
}