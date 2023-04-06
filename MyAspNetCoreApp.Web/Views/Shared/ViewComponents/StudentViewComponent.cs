using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class StudentViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentViewComponent(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var students = _context.Students.Select(x=> new StudentViewModel()
            {
                Id = x.Id,
                FirstName=x.FirstName,
                LastName=x.LastName
            }).ToList();
           
            return View();
        }
    
    }
}
