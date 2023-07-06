using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Validators.Generics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Business.Services.GenericCrudManagers
{
    public abstract class CrudService<TDto, TSummary, TEntity> : ICrudService<TDto, TSummary> where TEntity : class, IEntity, new()
    {
        protected readonly TourDbContext _context;
        protected readonly IValidator<TEntity> _validator;

        public CrudService(TourDbContext context, IValidator<TEntity> validator)
        {
            _context = context;
            _validator = validator;
        }

        protected abstract TEntity MapToEntity(TDto entity);
        protected abstract Expression<Func<TEntity , TDto>> DtoMapper {  get; }
        protected abstract Expression<Func<TEntity, TSummary>> SummaryMapper { get; }

        public virtual CommandResult Create(TDto dto)
        {
            try
            {
                var entity = MapToEntity(dto);
                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    var validationMessages =string.Join('\n',validationResult.Messages);
                    return CommandResult.Failure(validationMessages);
                }
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();
                
            }
        }

        public virtual CommandResult Delete(TDto dto)
        {
            var entity = MapToEntity(dto);
            return Delete(entity.Id);
        }

        public virtual CommandResult Delete(int id)
        {
            try
            {
                var entity = new TEntity() { Id = id };
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    _context.SaveChanges();

                    return CommandResult.Success();
                }
                else
                {
                    return CommandResult.Failure("Kayıt bulunamadı");
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure();

            }
        }

        public virtual IEnumerable<TDto> GetAll()
        {
            try
            {
                return _context.Set<TEntity>()
                      .Select(DtoMapper)
                      .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<TDto>();
            }
        }

        public virtual TDto? GetById(int id)
        {
            try
            {
                return _context.Set<TEntity>()
                    .Where(x => x.Id == id)
                    .Select(DtoMapper)
                    .SingleOrDefault();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public virtual IEnumerable<TSummary> GetSummaries()
        {
             try
                {
                   return _context.Set<TEntity>()
                          .Select(SummaryMapper)
                          .ToList();

                }
             catch (Exception ex)
                {
                    Trace.TraceError(ex.ToString());
                    return Enumerable.Empty<TSummary>();
                }
        }

        public virtual TSummary? GetSummaryById(int id)
        {
             try
                {
                    return _context.Set<TEntity>()
                            .Where(x=>x.Id == id)
                            .Select(SummaryMapper)
                            .SingleOrDefault();

                }
            catch (Exception ex)
                {
                    Trace.TraceError (ex.ToString());
                    return default;
                    
                }
        }

        public virtual CommandResult Update(TDto dto)
        {
             try
                {
                    var entity = MapToEntity(dto);
                    
                    _context.Set<TEntity>().Update(entity);
                    _context.SaveChanges();

                return CommandResult.Success();

                }
            catch (Exception ex)
                {
                  Trace.TraceError(ex.ToString());
                return CommandResult.Failure();  
                    
                }
        }
    }
}
