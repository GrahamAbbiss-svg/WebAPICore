
using System.ComponentModel.DataAnnotations;

namespace MVCCallAPICore.Models
{
    public class CaseNotesVm
    {
        public int CaseHeaderId { get; set; }
        public string NoteTypeId { get; set; }
        public string Author { get; set; }
        public string CaseNoteDesc { get; set; }
        [Required]
        [Display(Name = "Add a Note to the Case")]
        public string NoteText { get; set; }
        public string Document { get; set; }
    }
}
