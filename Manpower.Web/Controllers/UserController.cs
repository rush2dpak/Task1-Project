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
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/users")]
    public class UserController : ApiControllerBase
    {
        public UserController(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork _unitOfWork)
            : base(dataRepositoryFactory, _unitOfWork) { }


        [Route("latest")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            _requiredRepositories = new List<Type>() { typeof(User) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;
                var users = _usersRepository.GetAll().OrderByDescending(m => m.UserName).Take(6).ToList();

                IEnumerable<UserViewModel> usersVM = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

                response = request.CreateResponse<IEnumerable<UserViewModel>>(HttpStatusCode.OK, usersVM);

                return response;
            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getRole/{id:int}")]
        public HttpResponseMessage GetRole(HttpRequestMessage request, string id)
        {

            _requiredRepositories = new List<Type>() { typeof(User) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                var user = _usersRepository.GetAll().Where(y => y.UserName == id).SingleOrDefault();

                UserViewModel userVM = Mapper.Map<User, UserViewModel>(user);

                response = request.CreateResponse<UserViewModel>(HttpStatusCode.OK, userVM);

                return response;
            });

        }

        [HttpGet]
        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            _requiredRepositories = new List<Type>() { typeof(User) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                var user = _usersRepository.GetSingle(id);

                UserViewModel userVM = Mapper.Map<User, UserViewModel>(user);

                response = request.CreateResponse<UserViewModel>(HttpStatusCode.OK, userVM);

                return response;
            });
        }

        [Route("{page:int=0}/{pageSize=3}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            _requiredRepositories = new List<Type>() { typeof(User) };
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;
                List<User> users = null;

                int totalUsers = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    users = _usersRepository.GetAll()
                        .OrderBy(m => m.ID)
                        .Where(m => m.UserName.ToLower()
                        .Contains(filter.ToLower().Trim()))
                        .ToList();
                }
                else
                {
                    users = _usersRepository.GetAll().Where(y => y.Cancel == false).ToList();
                }

                totalUsers = users.Count();
                users = users.Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                IEnumerable<UserViewModel> usersVM = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);

                PaginationSet<UserViewModel> pagedSet = new PaginationSet<UserViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalUsers,
                    TotalPages = (int)Math.Ceiling((decimal)totalUsers / currentPageSize),
                    Items = usersVM
                };

                response = request.CreateResponse<PaginationSet<UserViewModel>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, UserViewModel user)
        {
            _requiredRepositories = new List<Type>() { typeof(User) };

            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                User newUser = new User();
                newUser.UpdateUser(user);



                _usersRepository.Add(newUser);

                _unitOfWork.Commit();

                // Update view model
                user = Mapper.Map<User, UserViewModel>(newUser);
                response = request.CreateResponse<UserViewModel>(HttpStatusCode.Created, user);

                //}

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, UserViewModel user)
        {
            _requiredRepositories = new List<Type>() { typeof(User) };
            return CreateHttpResponse(request, _requiredRepositories, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    if (user.Cancel == true)
                    {
                        var userDb = _usersRepository.GetSingle(user.ID);
                        userDb.Cancel = true;
                        _usersRepository.Edit(userDb);

                        _unitOfWork.Commit();


                        response = request.CreateResponse<UserViewModel>(HttpStatusCode.OK, null);
                    }
                    else
                    {
                        var userDb = _usersRepository.GetSingle(user.ID);
                        if (userDb == null)
                            response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid User..");
                        else
                        {
                            userDb.UpdateUser(user);

                            _usersRepository.Edit(userDb);

                            _unitOfWork.Commit();

                            user = Mapper.Map<User, UserViewModel>(userDb);
                            response = request.CreateResponse<UserViewModel>(HttpStatusCode.OK, user);
                        }
                    }
                }
                return response;
            });
        }

    }
}