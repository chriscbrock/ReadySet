using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadySet.ViewModels
{
    class CommandViewModel : BaseViewModel
    {
        public CommandViewModel()
        {
            Foo = "bar";

            Changed(() => Foo);
        }


        public string Foo { get; set; }
    }
}
