using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebAPI.Models
{
    public class UpdateNoteDto : IMapWith<UpdateNoteDto>
    {

        public  Guid NoteId { get; set; }
        public string NoteName { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.NoteId,
                    opt => opt.MapFrom(noteDto => noteDto.NoteId))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.NoteName,
                    opt => opt.MapFrom(noteDto => noteDto.NoteName))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
    
}
