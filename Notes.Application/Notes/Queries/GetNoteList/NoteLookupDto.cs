using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain1;

namespace Notes.Application.Notes.Queries.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid NoteId { get; set; }
        public string NoteName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.NoteId,
                    opt => opt.MapFrom(note => note.NoteId))
                .ForMember(noteDto => noteDto.NoteName,
                    opt => opt.MapFrom(note => note.NoteName));
        }
    }
}
