using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayCoreClassWork3.WebAPI.Core.API.Abstract;
using PayCoreClassWork3.WebAPI.Core.Business.Abstract;
using PayCoreClassWork3.WebAPI.Core.DataAccess.Concrete;
using PayCoreClassWork3.WebAPI.Core.Dto.Abstract;
using PayCoreClassWork3.WebAPI.Core.Entity.Concrete;
using PayCoreClassWork3.WebAPI.Utilities;

namespace PayCoreClassWork3.WebAPI.Core.API.Concrete.Controllers
{
    // Diğer controller'lar buradan kalıtım alır.
    // Bu controller ise sisteme ait olan ControllerBase sınıfından kalıtım alır.
    // Bu controller bir köprü görevi görmektedir. NonAction bir metod olan GetById metoduna sahiptir.
    // TEntity, CoreEntity sınıfından kalıtım almış bir sınıf olmak zorundadır.
    // TDto, ICoreDto interface'ini implemente almış bir nesne olmak zorundadır.
    // TService, IService'ın generic operatörünün değerine yazılan tipten implemente etmiş bir sınıf olmak zorundadır.
    public class CoreController<TEntity, TDto, TService> : ControllerBase, ICoreController<TEntity, TDto>
        where TEntity : CoreEntity
        where TDto : ICoreDto
        where TService : IService<TEntity>
    {
        private readonly TService _service;
        private readonly IMapper _mapper;

        // Gerekli kurucu metod yazılır. Generic olarak belirlenen servis tipindeki nesnenin bağımlılığı eklenir.
        public CoreController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // Tüm kayıtları listeleme.
        [HttpGet]
        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _service.GetAll();
        }

        // Id'ye göre tek bir kayıt getirme.
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(long? id)
        {
            if (id == null)
                return BadRequest(SystemMessage.ID_NULL);

            var entity = await _service.GetById((long)id);

            if (entity == null)
                return NotFound(SystemMessage.NOT_FOUND);

            return entity;
        }

        // Yeni bir kayıt ekleme.
        [HttpPost]
        public virtual async Task<ActionResult> Add([FromBody] TDto dto)
        {
            await _service.StartTransactionalOperation(Operation.Add, _mapper.Map<TEntity>(dto));
            return Ok(SystemMessage.ADDED);
        }

        // Mevcut bir kaydı güncelleme.
        [HttpPut]
        public virtual async Task<ActionResult> Update(long? id, [FromBody] TDto dto)
        {
            if (id == null)
                return BadRequest(SystemMessage.ID_NULL);

            var entity = await _service.GetById((long)id);

            if (entity == null)
                return NotFound(SystemMessage.NOT_FOUND);

            var mapped = _mapper.Map<TEntity>(dto);
            await _service.StartTransactionalOperation(Operation.Update, entity, mapped);
            return Ok(SystemMessage.UPDATED);
        }

        // Mevcut bir kaydı silme.
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
                return BadRequest(SystemMessage.ID_NULL);

            var entity = await _service.GetById((long)id);

            if (entity == null)
                return NotFound(SystemMessage.NOT_FOUND);

            await _service.StartTransactionalOperation(Operation.Delete, entity);
            return Ok(SystemMessage.DELETED);
        }
    }
}