using Godot;
using System;

public partial class MovementScript : Node3D
{
	private float m_moveSpeed = 13.0f;
	private float m_rotationSpeed = 3.5f;
	private bool m_movement;
	
	AnimationTree m_animPlayer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		m_animPlayer = GetNode("AnimationPlayer").GetNode("AnimationTree") as AnimationTree;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector3 position = new Vector3();
		
		float rotateValue = 0;
		
		if (Input.IsActionPressed("move_right"))
		{
		// Move as long as the key/button is pressed.
			rotateValue -= m_rotationSpeed * (float)delta;
   		}
		if (Input.IsActionPressed("move_left"))
		{
		// Move as long as the key/button is pressed.
			rotateValue += m_rotationSpeed * (float)delta;
   		}
	
		RotateY(rotateValue);
	
		if (Input.IsActionPressed("move_up"))
		{
		// Move as long as the key/button is pressed.
		position.X += m_moveSpeed * (float)delta;
   		}
		if (Input.IsActionPressed("move_down"))
		{
		// Move as long as the key/button is pressed.
		position.X -= m_moveSpeed * (float)delta;
   		}
		
		Translate(position);
		
		if (position == Vector3.Zero)
		{
			double lerpValue = Mathf.Lerp((double)(m_animPlayer.Get("parameters/MovementBlend/blend_amount")), 0, delta);
			m_animPlayer.Set("parameters/MovementBlend/blend_amount", lerpValue);
		}
		else
		{
			GD.Print("Moving");
			double lerpValue = Mathf.Lerp((double)(m_animPlayer.Get("parameters/MovementBlend/blend_amount")), 1, delta);
			GD.Print((double)(m_animPlayer.Get("parameters/MovementBlend/blend_amount")));
			GD.Print(lerpValue);
			m_animPlayer.Set("parameters/MovementBlend/blend_amount", lerpValue);
		}
	}
}
