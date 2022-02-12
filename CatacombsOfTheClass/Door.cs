namespace CatacombsOfTheClass;

internal class Door
{
    private int _passcode;

    public DoorState State { get; private set; }

    public Door (int passcode)
    {
        _passcode = passcode;
        State = DoorState.Locked;
    }

    public bool ProcessCommand(string command)
    {
        switch (command.ToLower())
        {
            case "open":
                return TransitionState(DoorState.Open);
            case "close":
                return TransitionState(DoorState.Unlocked);
            case "lock":
                return TransitionState(DoorState.Locked);
            case "unlock":
                return AttemptUnlock();
            case "change passcode":
                return ChangePasscode();
            default:
                return false;
        }
    }
    private bool ChangePasscode()
    {
        if(!EnterPasscode())
            return false;
        Console.Write("Enter new passcode: ");
        var newPasscode = Convert.ToInt32(Console.ReadLine());
        _passcode = newPasscode;
        return true;
    }

    private bool AttemptUnlock()
    {
        if(!IsValidTransition(DoorState.Unlocked) || !EnterPasscode())
            return false;

        State = DoorState.Unlocked;
        return true;
    }
    private bool EnterPasscode()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Enter Passcode: ");
        Console.ForegroundColor = ConsoleColor.White;
        var attempt = Convert.ToInt32(Console.ReadLine());

        if (attempt != _passcode)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect Passcode.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        return true;
    }

    private bool TransitionState(DoorState targetState)
    {
        if (!IsValidTransition(targetState) || State == DoorState.Locked)
            return false;

        State = targetState;
        return true;
    }

    private bool IsValidTransition(DoorState targetState)
    {
        return State switch
        {
            DoorState.Locked => targetState == DoorState.Unlocked,
            DoorState.Open => targetState == DoorState.Unlocked,
            DoorState.Unlocked => targetState == DoorState.Locked || targetState == DoorState.Open,
            _ => false
        };
    }
    public enum DoorState
    {
        Open,
        Unlocked,
        Locked
    }
}
