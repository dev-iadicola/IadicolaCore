using System;

namespace IadicolaCore.Log;
public class ExceptionLog : Exception
{
    private readonly string _message;
    private readonly Exception? _inner;
    private readonly bool _exit;

    // Costruttore principale (usa un'eccezione interna opzionale)
    public ExceptionLog(string message, Exception? inner = null, bool exit = true)
        : base(message, inner)
    {
        _message = message;
        _inner = inner;
        _exit = exit;
        Print();
    }

    //  Costruttore semplificato (solo messaggio e opzione uscita)
    public ExceptionLog(string message, bool exit = false)
        : base(message)
    {
        _message = message;
        _exit = exit;
        _inner = null;
        Print();
    }

    private void Print()
    {
        if (_inner != null)
        {
            Logger.Error($"[ERROR] {_message}");
            Logger.Log($"Type Error: {_inner.GetType().Name}\nMessage: {_inner.Message}\nStackTrace: {_inner.StackTrace}");
        }
        else
        {
            Logger.Warning($"[WARNING] {_message}");
        }

        if (_exit)
        {

            Environment.Exit(1);
        }
    }
}
