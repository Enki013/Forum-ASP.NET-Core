using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvcIdentity.Models;
using AspNetCoreMvcIdentity.Models.ForumViewModels;
using AspNetCoreMvcIdentity.Models.PostViewModels;
using AspNetCoreMvcIdentity.Services;
using AspNetCoreMvcIdentity.Application.Forums.Commands.DeleteForum;
using AspNetCoreMvcIdentity.Application.Forums.Queries.GetForumById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;

namespace AspNetCoreMvcIdentity.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forum;
        private readonly IPost _post;
        private readonly MediatR.IMediator _mediator;
        private readonly IMapper _mapper;

        public ForumController(IForum forum, IPost post, MediatR.IMediator mediator, IMapper mapper)
        {
            _forum = forum;
            _post = post;
            _mediator = mediator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var forums = _forum.GetAll().ToList();
            var forumModels = _mapper.Map<IEnumerable<ForumListingModel>>(forums);

            var model = new ForumIndexModel
            {
                ForumList = forumModels.OrderBy(f => f.Title)
            };

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var forum = await _mediator.Send(new GetForumByIdQuery { ForumId = id });
            var model = _mapper.Map<ForumListingModel>(forum);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new DeleteForumCommand { ForumId = id });
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id, string searchQuery)
        {
            var forum = await _mediator.Send(new GetForumByIdQuery { ForumId = id });
            if (forum == null)
            {
                return NotFound();
            }
        
            var posts = _post.GetFilteredPosts(forum, searchQuery).ToList();
       
            var postListings = posts.Select(p => {
                var listing = _mapper.Map<PostListingModel>(p);
                listing.Forum = _mapper.Map<ForumListingModel>(p.Forum);
                return listing;
            });

            var model = new ForumDetailsModel
            {
                Posts = postListings,
                Forum = _mapper.Map<ForumListingModel>(forum),
                SearchQuery = searchQuery
            };

            return View(model);
        }

    
        [HttpPost]
        public IActionResult Search(int id, string searchQuery)
        {
            return RedirectToAction("Details", new { id, searchQuery });

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            var model = new AddForumModel();

            return View(model);

        }
        [HttpPost]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddForum(AddForumModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", model);
            }

            var command = new AspNetCoreMvcIdentity.Application.Forums.Commands.CreateForum.CreateForumCommand
            {
                Title = model.Title,
                Description = model.Description,
                ImageUpload = model.ImageUpload
            };

            await _mediator.Send(command);
            
            return RedirectToAction("Index", "Forum");
        }
    }
}