using Newtonsoft.Json;

namespace Dynamic_Application.Core
{
    public class CandidateApplication
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("firstName")]
        public string? FirstName { get; set; }
        [JsonProperty("lastName")]
        public string? LastName { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("phone")]
        public string? Phone { get; set; }
        [JsonProperty("nationality")]
        public string? Nationality { get; set; }
        [JsonProperty("currentResidence")]
        public string? CurrentResidence { get; set; }
        [JsonProperty("idNumber")]
        public string? IdNumber { get; set; }
        [JsonProperty("dateOfBirth")]
        public DateTime? DateofBirth { get; set; }
        [JsonProperty("gender")]
        public string? Gender { get; set; }

        [JsonProperty("paragraphAnswers")]
        public List<ParagraphAnswers>? ParagraphAnswers { get; set; }
        [JsonProperty("dropdownAnswers")]
        public List<DropdownAnswers>? DropdownAnswers { get; set; }
        [JsonProperty("yesNoAnswers")]
        public List<YesNoAnswers>? YesNoAnswers { get; set; }
        [JsonProperty("multipleAnswers")]
        public List<MultipleAnswers>? MultipleAnswers { get; set; }
        [JsonProperty("numericAnswers")]
        public List<NumericAnswers>? NumericAnswers { get; set; }
        [JsonProperty("dateAnswers")]
        public List<DateAnswers>? DateAnswers { get; set; }


    }

    public class ParagraphAnswers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public string Answer { get; set; }
    }

    public class DropdownAnswers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public string Answer { get; set; }
    }

    public class YesNoAnswers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
       
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public string Answer { get; set; }
    }
    public class MultipleAnswers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public List<String> Answer { get; set; }

    }

    public class NumericAnswers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
       
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public int Answer { get; set; }
    }

    public class DateAnswers
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("Answer")]
        public DateTime Answer { get; set; }
    }
}
