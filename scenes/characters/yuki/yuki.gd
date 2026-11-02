extends CharacterBody2D


@export var SPEED := 200.0
@export var acceleration := 10.0
@onready var animated_sprite_2D = $AnimatedSprite2D

var animation_direction: String = "down"
var animation_state: String = ""

func update_sprite_direction(input: Vector2) -> void:
	if input.is_zero_approx():
		return

	if absf(input.x) > absf(input.y):
		animation_direction = "right" if input.x > 0.0 else "left"
	else:
		animation_direction = "down" if input.y > 0.0 else "up"

func update_sprite() -> void:
	if velocity.length() > 0:
		animation_state = "move_"
	else:
		animation_state = "idle_"

func _physics_process(delta: float) -> void:
	var input_direction := Input.get_vector(
		"move_left", "move_right", "move_up", "move_down"
	)

	update_sprite_direction(input_direction)

	# Immediate response: no coasting after releasing input.
	velocity = input_direction * SPEED

	var previous_position := global_position
	move_and_slide()

	# Stay idle when blocked by a wall.
	var actual_speed := global_position.distance_to(previous_position) / delta
	animation_state = "move_" if actual_speed > 1.0 else "idle_"

	animated_sprite_2D.play(animation_state + animation_direction)
