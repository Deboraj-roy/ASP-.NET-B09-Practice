// See https://aka.ms/new-console-template for more information
using Events;

Console.WriteLine("Event, World!");

TextBox textBox1 = new TextBox();
textBox1.OnTextChanged += PrintText;
textBox1.OnTextChanged += PrintText2;

textBox1.AddText("hello");

textBox1.OnTextChanged -= PrintText2;
textBox1.AddText(textBox1.Text + " hello");


void PrintText2(string obj)
{
    Console.WriteLine(obj);
}

void PrintText(string obj)
{
    Console.WriteLine(obj);

}

textBox1.OnTextChanged += PrintText2;


