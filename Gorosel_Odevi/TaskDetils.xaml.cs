using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gorosel_Odevi;

public partial class TaskDetils : ContentPage
{
    public bool Result = false;
   // public Note  mNote = null;
    bool edit = false;

    //public Action<Note> AddMethod = null;
    public TaskDetils(   )
    {
        InitializeComponent();

      /*  if (note == null)
        {
            //GetTask = new Note();
            edit = false;
        }
        else
        {
          //  txtnote.Text = note.Ad;
         
           // GetTask = note;
            edit = true;

        }*/

    }

       

    private void OKClicked(object sender, EventArgs e)
    {
        Result = true;
      //  GetTask.Note = txtnote.Text;


        if (!edit)
        {
         //   if (AddMethod != null)
               // AddMethod(GetTask);

        }

        Navigation.PopModalAsync();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Result = false;
        Navigation.PopModalAsync();
    }


}
