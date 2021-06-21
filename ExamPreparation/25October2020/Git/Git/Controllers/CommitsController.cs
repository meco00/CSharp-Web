using Git.Data;
using Git.Data.Models;
using Git.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Linq;

using static Git.Data.DataConstants;

namespace Git.Controllers
{
   public class CommitsController:Controller
    {
        private readonly ApplicationDbContext data;

        public CommitsController(ApplicationDbContext data)
        {
            this.data = data;
        }


        [Authorize]
        public ActionResult Create(string Id)
        {
            var repositoryName = data.Repositories.Find(Id).Name;

            var repoDto = new CommitRepositoryCreateViewModel
            {
                Id = Id,
                Name = repositoryName
            };

           return this.View(repoDto);

        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CommitCreateViewModel model)
        {
            if (!data.Repositories.Any(x=>x.Id==model.Id))
            {
                return BadRequest();
            }

            if (model.Description.Length < CommitDescriptionMinLength)
            {
                return Error($"Description must be at least {CommitDescriptionMinLength} characters long");
            }

            var commitToImport = new Commit
            {
                RepositoryId = model.Id,
                Description = model.Description,
                CreatorId = this.User.Id
            };

            data.Commits.Add(commitToImport);

            data.SaveChanges();

            return Redirect("/Repositories/All");

        }


        [Authorize]
        public ActionResult All()
        {
            var commitsDto = this.data.Commits
                .Where(x => x.CreatorId == this.User.Id)
                .OrderByDescending(x=>x.CreatedOn)
                .Select(x => new CommitAllViewModel
                {
                    Id = x.Id,
                    Repository = x.Repository.Name,
                    Description = x.Description,
                    CreatedOn = x.CreatedOn.ToLocalTime().ToString()
                })
                .ToList();
            


            return this.View(commitsDto);

        }

        [Authorize]
        public ActionResult Delete(string Id)
        {
            var commit = data.Commits.FirstOrDefault(x=>x.Id==Id);

            if (commit==null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            data.Commits.Remove(commit);

            data.SaveChanges();

            return this.Redirect("/Commits/All");
        }


    }

    }

