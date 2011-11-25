using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Juanagui.Validation;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;
using Validator = Juanagui.Validation.Validator;
using System.ComponentModel;

namespace LessonsLearned.PresentationModel
{
    public class SearchForm : PresentationModelBase, IValid
    {
        private readonly PersonSearchFormDto _personSearchFormDto;

        public SearchForm()
            : this(new PersonSearchFormDto())
        { }

        private SearchForm(PersonSearchFormDto personSearchFormDto)
        {
            _personSearchFormDto = personSearchFormDto;
        }

        [Required]
        public String Forename
        {
            get { return _personSearchFormDto.Forename; }
            set
            {
                _personSearchFormDto.Forename = value;
                RaisePropertyChanged(() => Forename);
            }
        }

        [Required]
        public String Surname
        {
            get { return _personSearchFormDto.Surname; }
            set
            {
                _personSearchFormDto.Surname = value;
                RaisePropertyChanged(() => Surname);
            }
        }

        public void Reset()
        {
            Forename = null;
            Surname = null;
        }

        public PersonSearchFormDto ToDto()
        {
            return _personSearchFormDto;
        }

        public string this[string columnName]
        {
            get { return this.GetErrorData(columnName); }
        }

        public string Error
        {
            get
            {
                return this.GetAllErrors(" ");
            }
        }

        public bool IsValid
        {
            get { return this.IsValid(); }
        }
    }
}
