using AutoMapper;
using Manpower.Data.Infrastructure;
using Manpower.Data.Repositories;
using Manpower.Entities;
using Manpower.Services;
using Manpower.Services.Utilities;
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
using Manpower.Web.Infrastructure.Extensions;

namespace Manpower.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerB
    {
        private readonly IMembershipService _membershipService;
        private readonly IEntityBaseRepository<User> _userRepository;
       
       

        public AccountController(IMembershipService membershipService,
            IEntityBaseRepository<Error> _errorsRepository, IEntityBaseRepository<User> userRepository,
           
         
            IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _membershipService = membershipService;
            _userRepository = userRepository;
            
         
        }

        [AllowAnonymous]
        [Route("role")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            HttpResponseMessage response = null;


            var roles = _membershipService.GetRoles();

            IEnumerable<RoleViewModel> rolesVM = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(roles);

            response = request.CreateResponse<IEnumerable<RoleViewModel>>(HttpStatusCode.OK, rolesVM);

            return response;

        }


        [AllowAnonymous]
        [HttpGet]
        [Route("getRole/{username}")]
        public HttpResponseMessage GetRole(HttpRequestMessage request, string username)
        {

            HttpResponseMessage response = null;

            var user = _userRepository.GetSingleByUsername(username);

            UserViewModel userVM = Mapper.Map<User, UserViewModel>(user);

            response = request.CreateResponse<UserViewModel>(HttpStatusCode.OK, userVM);

            return response;

        }


        //[AllowAnonymous]
        //[HttpGet]
        //[Route("getCompany/{id:int}")]
        //public HttpResponseMessage GetCompany(HttpRequestMessage request, int id)
        //{

        //    HttpResponseMessage response = null;

        //    var company = _companyInfoRepository.GetSingle(id);

        //    CompanyInfoViewModel companyVM = Mapper.Map<CompanyInfo, CompanyInfoViewModel>(company);

        //    response = request.CreateResponse<CompanyInfoViewModel>(HttpStatusCode.OK, companyVM);

        //    return response;

        //}


       
        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, UserViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Entities.User _user = _membershipService.CreateUser(user.UserName, user.Email, user.Password, user.Phone,
                                            user.Sex, user.Remarks, user.Address, user.RoleId, user.CompanyInfoId, user.ClientNoticeId, new int[] { user.RoleId });

                    if (_user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });
        }
    }
}
