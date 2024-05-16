using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dynamic_Application.Core
{
    public class EmployerProgram
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("programTitle")]
        public string ProgramTitle { get; set; }
        [JsonProperty("programDescription")]
        public string ProgramDescription { get; set; }
        [JsonProperty("firstName")]
        public bool FirstName { get; set; }
        [JsonProperty("lastName")]
        public bool LastName { get; set; }
        [JsonProperty("email")]
        public bool Email { get; set; }
        [JsonProperty("phone")]
        public Phone Phone { get; set; }
        [JsonProperty("nationality")]
        public Nationality Nationality { get; set; }
        [JsonProperty("currentResidence")]
        public CurrentResidence CurrentResidence { get; set; }
        [JsonProperty("idNumber")]
        public IdNumber IdNumber { get; set; }
        [JsonProperty("dateOfBirth")]
        public DateofBirth DateofBirth { get; set; }
        [JsonProperty("gender")]
        public Gender Gender { get; set; }
        [JsonProperty("paragraphQuestions")]
        public List<ParagraphQuestions>? ParagraphQuestions { get; set; }
        [JsonProperty("dropdownQuestions")]
        public List<DropdownQuestions>? DropdownQuestions { get; set; }
        [JsonProperty("yesNoQuestions")]
        public List<YesNoQuestions>? YesNoQuestions { get; set; }
        [JsonProperty("multipleQuestions")]
        public List<MultipleQuestions>? MultipleQuestions { get; set; }
        [JsonProperty("numericQuestions")]
        public List<NumericQuestions>? NumericQuestions { get; set; }
        [JsonProperty("dateQuestions")]
        public List<DateQuestions>? DateQuestions { get; set; }


    }

    public class ParagraphQuestions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
    }

    public class DropdownQuestions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("choices")]
        public List<String> Choices { get; set; }
        [JsonProperty("enableOther")]
        public bool EnableOther { get; set; }
    }

    public class YesNoQuestions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
    }
    public class MultipleQuestions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
        [JsonProperty("choices")]
        public List<String> Choices { get; set; }
        [JsonProperty("enableOther")]
        public bool EnableOther { get; set; }
        [JsonProperty("choicesAllowed")]
        public int ChoicesAllowed { get; set; }

    }

    public class NumericQuestions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
    }

    public class DateQuestions
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("question")]
        public string Question { get; set; }
    }
    public class Phone
    {
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }
    public class Nationality
    {
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }
    public class CurrentResidence
    {
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }
    public class IdNumber
    {
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }

    public class DateofBirth
    {
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }
    public class Gender
    {
        [JsonProperty("internal")]
        public bool Internal { get; set; }
        [JsonProperty("hide")]
        public bool Hide { get; set; }
    }

}
