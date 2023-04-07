using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Controllers;
using MyAspNetCoreApp.Web.Models;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class StudentListViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentListViewComponent(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var students = _context.Students.Where(x => x.Id == id ).ToList();
            var studentViewModels = _mapper.Map<List<StudentViewModel>>(students);
            return View(studentViewModels);
        }
        //
    }
}
