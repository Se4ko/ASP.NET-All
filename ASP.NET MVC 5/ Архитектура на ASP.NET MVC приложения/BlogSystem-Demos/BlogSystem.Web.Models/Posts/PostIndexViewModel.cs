namespace BlogSystem.Web.ViewModels.Posts
{
    using System;
    using System.Linq;

    using BlogSystem.Model;
    using BlogSystem.Web.Infrastructure.Mappings;
    using System.Linq.Expressions;
    using AutoMapper;
    using System.ComponentModel.DataAnnotations;

    public class PostIndexViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        [Required]
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public int TagsCount { get; set; }

        public string TitleLength { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, PostIndexViewModel>()
                .ForMember(p => p.TagsCount, opt => opt.MapFrom(p => p.Tags.Count()))
                .ForMember(p => p.TitleLength, opt => opt.MapFrom(p => p.Title.Count()))
                .ReverseMap();
        }
    }
}