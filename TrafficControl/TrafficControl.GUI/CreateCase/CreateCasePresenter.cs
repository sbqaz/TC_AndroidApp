using System.Collections.Generic;
using System.Linq;
using TrafficControl.BLL.CreateCase;

namespace TrafficControl.GUI.CreateCase
{
    class CreateCasePresenter : ICreateCasePresenter
    {
        private readonly ICreateCaseView _view;
        private readonly ICreateCaseModel _model;

        public CreateCasePresenter(ICreateCaseView view, ICreateCaseModel model)
        {
            _view = view;
            _model = model;
        }

        public List<string> Installations
        {
            get
            {
                string[] languages = { "C", "C++", "Java", "C#", "PHP", "JavaScript", "jQuery", "AJAX", "JSON" };
                return languages.ToList();
            }
        }
    }
}