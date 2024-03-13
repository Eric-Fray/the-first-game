using System.Diagnostics.Eventing.Reader;
using Godot;

public partial class Mob : RigidBody2D 
{
    [Signal]
    public delegate void LeaveScreenHandler();
    
    public override void _Ready()
    {
        var animatedSprite2D = GetNode<AnimatedSprite>("AnimatedSprite");
        string[] mobTypes = animatedSprite2D.Frames.GetAnimationNames();
        animatedSprite2D.Play(mobTypes[GD.Randi() % mobTypes.Length]);
    }
    
    private void OnVisibleOnScreenNotifier2DScreenExited()
    {
        QueueFree();
    }
}