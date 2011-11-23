using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LessonsLearned.DomainModel.Workflows.PersonVerification.Dtos;

namespace LessonsLearned.PresentationModel
{
    public class SearchForm : PresentationModelBase
    {
        private readonly PersonSearchFormDto _personSearchFormDto;

        public SearchForm()
            : this(new PersonSearchFormDto())
        { }

        private SearchForm(PersonSearchFormDto personSearchFormDto)
        {
            _personSearchFormDto = personSearchFormDto;
        }

        private string _forename;

        public PersonSearchFormDto ToDto()
        {
            return _personSearchFormDto;
        }

        public String Forename
        {
            get { return _forename; }
            set
            {
                _forename = value;
                RaisePropertyChanged(() => Forename);
            }
        }

        private string _surname;
        public String Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                RaisePropertyChanged(() => Surname);
            }
        }


    }
}
