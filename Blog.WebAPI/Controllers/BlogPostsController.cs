using Blog.Application.Features.CategoryFeatures.CreateCategory;
using Blog.Application.Features.CategoryFeatures;
using Blog.Application.ServiceContracts.BlogPostServiceContracts;
using Blog.Application.ServiceContracts.CategoryServiceContracts;
using Blog.Application.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blog.Application.Features.BlogPostFeatures.CreateBlogPost;

namespace Blog.WebAPI.Controllers
{
    public class BlogPostsController : CustomControllerBase
    {
        private readonly IBlogPostAdderService _blogPostAdderService;
        private readonly IBlogPostGetterService _blogPostGetterService;
        private readonly IBlogPostDeleterService _blogPostDeleterService;
        private readonly IBlogPostUpdaterService _blogPostUpdaterService;

        public BlogPostsController(IBlogPostAdderService blogPostAdderService, IBlogPostGetterService blogPostGetterService, IBlogPostDeleterService blogPostDeleterService, IBlogPostUpdaterService blogPostUpdaterService)
        {
            _blogPostAdderService = blogPostAdderService;
            _blogPostGetterService = blogPostGetterService;
            _blogPostDeleterService = blogPostDeleterService;
            _blogPostUpdaterService = blogPostUpdaterService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequest request)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            BlogPostResponse response = await _blogPostAdderService.AddBlogPost(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            List<BlogPostResponse> blogPostResponseList = await _blogPostGetterService.GetAllBlogPosts();
            return Ok(blogPostResponseList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult> GetBlogPostById([FromRoute] Guid Id)
        {
            BlogPostResponse? blogPostResponse = await _blogPostGetterService.GetBlogPostById(Id);
            if (blogPostResponse == null)
            {
                return Problem(statusCode: 404, title: "Not Found", detail: $"Blog post with ID {Id} was not found.");
            }
            return Ok(blogPostResponse);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateBlogPost(BlogPostUpdateRequest blogPostUpdateRequest, Guid Id)
        {
            if (Id != blogPostUpdateRequest.Id)
                return BadRequest("Id doesn't match");

            BlogPostResponse updatedBlogPost= await _blogPostUpdaterService.UpdateBlogPost(blogPostUpdateRequest);
            return Ok(updatedBlogPost);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBlogPost(Guid Id)
        {
            var isDeleted = await _blogPostDeleterService.DeleteBlogPostById(Id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
