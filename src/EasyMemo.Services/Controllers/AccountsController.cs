using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apworks.Repositories;
using Apworks.Specifications;
using EasyMemo.Domain.Model;

namespace EasyMemo.Services.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        private readonly IRepository<Account> accountRepository;
        private readonly IRepositoryContext unitOfWork;

        public AccountsController(IRepositoryContext unitOfWork, IRepository<Account> accountRepository)
        {
            this.accountRepository = accountRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("name/{name}")]
        public IHttpActionResult GetByName(string name)
        {
            var account = this.accountRepository.Find(Specification<Account>.Eval(acct => acct.Name == name));
            if (account != null)
            {
                return Ok(new
                {
                    account.Name,
                    account.DisplayName,
                    account.Email,
                    account.DateCreated,
                    account.DateLastLogon
                });
            }
            throw new Exception(string.Format("The account '{0}' does not exist.", name));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
