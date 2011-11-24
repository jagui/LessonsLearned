using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Juanagui.Validation;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;
using Validator = Juanagui.Validation.Validator;

namespace LessonsLearned.PresentationModel
{
    public class SearchForm : PresentationModelBase, IValid
    {
        private readonly PersonSearchFormDto _personSearchFormDto;
        private string _forename;
        private string _surname;

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
            get { return _forename; }
            set
            {
                _forename = value;
                RaisePropertyChanged(() => Forename);
            }
        }

        [Required]
        public String Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                RaisePropertyChanged(() => Surname);
            }
        }

        public PersonSearchFormDto ToDto()
        {
            return _personSearchFormDto;
        }

        public string this[string columnName]
        {
            get
            {

                return GetNotificationMessages()[columnName];
            }
        }

        public string Error
        {
            get
            {
                var error = new StringBuilder();
                foreach (var message in GetNotificationMessages())
                {
                    error.Append(message);
                }
                return error.ToString();
            }
        }

        public bool IsValid
        {
            get { return !GetNotificationMessages().Any(); }
        }

        private Notification GetNotificationMessages()
        {
            var notification = new Notification();
            Validator.Validate(this, notification);
            return notification;
        }
    }
}
