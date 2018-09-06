using CopierProject.Interfaces;

namespace CopierProject
{
    public class Copier
    {
        // IDestination and ISource belong to someone else
        private readonly IDestination _destination;
        private readonly ISource _source;

        public Copier(IDestination destination, ISource source)
        {
            _destination = destination;
            _source = source;
        }

        // This is a void method so we cannot test the state
        public void Copy()
        {
            var c = _source.GetChar();
            while (c != '\n')
            {
                _destination.SetChar(c);

                c = _source.GetChar();
            }
        }
    }
}
