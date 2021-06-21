using Git.Data;
using Git.Data.Models;
using Git.Services;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;

using static Git.Data.DataConstants;

namespace Git.Controllers
{
   public class RepositoriesController:Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(ApplicationDbContext dbContext, IValidator validator)
        {
            this.data = dbContext;
            this.validator = validator;
        }
        public ActionResult All()
        {
            var repo = data.Repositories.AsQueryable();
            
            if(!this.User.IsAuthenticated)
            {
                 repo = repo.Where(x => x.IsPublic);
            }
            else
            {
                repo= repo.Where(x => x.IsPublic || x.OwnerId == this.User.Id);
            }

            var repositories = repo
                .OrderByDescending(x=>x.CreatedOn)
                .Select(x => new RepositoryAllViewModel
            {
                Id=x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn.ToLocalTime().ToString(),
                Owner = x.Owner.Username,
                CommitsCount = x.Commits.Count

            })
                .ToList();

            return this.View(repositories);
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(RepositoryCreateViewModel repository)
        {
            var errorList = this.validator.ValidateRepository(repository);
            
            if (errorList.Count > 0)
            {
                return Error(errorList);
            }

            var repoToImport = new Repository
            {
                Name = repository.Name,
                IsPublic = repository.RepositoryType == RepositoryPublicType ? true : false,
                OwnerId = this.User.Id,
                
            };

            data.Repositories.Add(repoToImport);

            data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
