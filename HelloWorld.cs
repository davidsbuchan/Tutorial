namespace Sse.EnergySystems.Sandbox
{
  using System;
  using System.Windows.Forms;
  
  public class HelloWorld : Form
  {
    private Button button;
  
    public HelloWorld()
	{
	  BuildForm();
	}
  
    [STAThread]
    static void Main(string[] args)
    {
      Application.Run(new HelloWorld());
    }
	
	public void BuildForm()
	{
	  button = new Button();
	  button.Text = "Hello World!";
	  
	  button.Click += ButtonClickMethod;
	  
	  Controls.Add(button);
	}
	
	private void ButtonClickMethod(object sender, System.EventArgs e)
	{
	  MessageBox.Show("Hello World!");
	}
  }
}