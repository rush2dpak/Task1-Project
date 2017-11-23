using Manpower.Data.Infrastructure;
using Manpower.Data.Repositories;
using Manpower.Entities;
using Manpower.Web.Infrastructure.Core;
using Manpower.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Manpower.Data.Extensions;
using AutoMapper;
using Manpower.Web.Infrastructure.Extensions;

namespace Manpower.Web.Controllers
{

    [RoutePrefix("api/dataRecord")]
    public class DataRecordController : ApiControllerBase
    {
        public DataRecordController(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork _unitOfWork)
            : base(dataRepositoryFactory, _unitOfWork) { }

        //[AllowAnonymous]
        //[Route("latest")]
        //public HttpResponseMessage Get(HttpRequestMessage request)
        //{
        //    _requiredRepositories = new List<Type>() { typeof(DataRecord) };

        //    return CreateHttpResponse(request, _requiredRepositories, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        var data = _dataRecordRepository.GetAll().OrderByDescending(m => m.DateJoined).ToList();

        //        IEnumerable<DataRecordViewModel> dataVM = Mapper.Map<IEnumerable<DataRecord>, IEnumerable<DataRecordViewModel>>(data);

        //        response = request.CreateResponse<IEnumerable<DataRecordViewModel>>(HttpStatusCode.OK, dataVM);

        //        return response;
        //    });
        //}
        [HttpGet]
        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            _requiredRepositories = new List<Type>() { typeof(DataRecord) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                var data = _dataRecordRepository.GetAll().Where(y => y.ID == id).SingleOrDefault();

                DataRecordViewModel dataVM = Mapper.Map<DataRecord, DataRecordViewModel>(data);

                response = request.CreateResponse<DataRecordViewModel>(HttpStatusCode.OK, dataVM);

                return response;
            });
        }


        [AllowAnonymous]
        [Route("{id:int=0}/{userrole:int=0}/{page:int=0}/{pageSize=2}/{filter?}")]
        public HttpResponseMessage GetTEST(HttpRequestMessage request, int? id, int? userrole, int? page, int? pageSize, string filter = null)
        {
            _requiredRepositories = new List<Type>() { typeof(DataRecord), typeof(User) };
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                List<DataRecord> dataVM = null;
                int totalData = new int();

                if (!string.IsNullOrEmpty(filter))

                {
                    dataVM = _dataRecordRepository.GetAll()
                       .OrderBy(m => m.ID)
                      .Where(m => m.Name.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .ToList();
                }
                else
                {
                  
                    //dataVM = _dataRecordRepository.GetAll().ToList();

                    if (id >= 1)
                    {
                        dataVM = _dataRecordRepository.GetAll().Where(y => y.Cancel == false).OrderByDescending(b => b.DateJoined).ToList();
                    }
                    else if (userrole == 1)
                    {
                        dataVM = _dataRecordRepository.GetAll().Where(y => y.Cancel == false).OrderBy(b => b.DateJoined).ToList();
                    }


                }

                totalData = dataVM.Count();
                dataVM = dataVM.Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                IEnumerable<DataRecordViewModel> data = Mapper.Map<IEnumerable<DataRecord>, IEnumerable<DataRecordViewModel>>(dataVM);

                PaginationSet<DataRecordViewModel> pagedSet = new PaginationSet<DataRecordViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalData,
                    TotalPages = (int)Math.Ceiling((decimal)totalData / currentPageSize),
                    Items = data
                };

                response = request.CreateResponse<PaginationSet<DataRecordViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, DataRecordViewModel data)
        {
            _requiredRepositories = new List<Type>() { typeof(DataRecord) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;
                DataRecord newData = new DataRecord();
                var existingAuthorCount = _dataRecordRepository.GetAll().Count(a => a.Name == data.Name);
                if (existingAuthorCount == 0)
                {
                    newData.UpdateData(data);

                    _dataRecordRepository.Add(newData);

                    _unitOfWork.Commit();

                    // Update view model
                    data = Mapper.Map<DataRecord, DataRecordViewModel>(newData);
                    response = request.CreateResponse<DataRecordViewModel>(HttpStatusCode.Created, data);
                }
                else
                {

                    response = request.CreateErrorResponse(HttpStatusCode.Conflict, ModelState);

                }
                return response;
            });
        }
        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, DataRecordViewModel record)
        {
            _requiredRepositories = new List<Type>() { typeof(DataRecord) };
            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                var recordDb = _dataRecordRepository.GetSingle(record.ID);

                recordDb.UpdateData(record);

                _dataRecordRepository.Edit(recordDb);

                _unitOfWork.Commit();

                record = Mapper.Map<DataRecord, DataRecordViewModel>(recordDb);
                response = request.CreateResponse<DataRecordViewModel>(HttpStatusCode.OK, record);

                return response;
            });
        }


        ////delete data       
        [HttpGet]
        [Route("remove/{id:int}")]
        public HttpResponseMessage Remove(HttpRequestMessage request, int id)
        {
            _requiredRepositories = new List<Type>() { typeof(DataRecord) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                DataRecord data = new DataRecord();
                data = _dataRecordRepository.GetSingle(id);
                _dataRecordRepository.Delete(data);
                _unitOfWork.Commit();

                response = request.CreateResponse<DataRecordViewModel>(HttpStatusCode.Created, null);
                return response;
            });
        }

    }
}