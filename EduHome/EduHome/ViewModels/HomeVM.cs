using EduHome.Models;
using System.Collections.Generic;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public About About { get; set; }
        public List<Course> Courses  { get; set; }
        public FeedBack FeedBack { get; set; }
        public List<NoticeBoard> NoticeBoards { get; set; }

    }
}
