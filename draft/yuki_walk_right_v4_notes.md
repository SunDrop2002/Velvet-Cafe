# Yuki walk-right v4 — implementation and verification

## Changes
- One reusable profile model, edited against the original idle. No independent generation of walking frames.
- Hair mapping uses only the canonical hair colors and matches their brightness distribution, rather than nearest colors from the entire sprite.
- Canonical hair luminance mean/median/90th percentile: 48.01 / 47.41 / 69.22. Profile model: 48.00 / 47.41 / 69.22.
- Relaxed side-profile face is fixed across the cycle. Head, hair and facial pixels are identical after compensating for the controlled body offset.
- Six poses built from saved head, torso, upper-arm, forearm, thigh, shin and foot layers. Legs use fixed-length two-bone poses. Arms move in opposite phase to their corresponding legs.
- Weight shift: 0, 1, 0, 0, 1, 0 pixels. Stance baseline stays at y90.
- 96×96 frames, transparent 576×96 PNG, 8 FPS, 0.75 seconds per loop.

## Verification
- Native-resolution and enlarged browser playback reviewed against canonical idle.
- Browser playback exercised repeated 6-to-1 transitions at 8 FPS, plus 25 FPS and a moving-ground comparison at 48 and 150 pixels/second.
- Godot 4.7.2 loaded the resource in an isolated test project and ran three live AnimatedSprite2D loops. The observed sequence was 1,2,3,4,5,0 repeated; measured frame intervals were 0.124–0.131 seconds.
- Zero output colors outside the canonical palette, binary alpha, all frame ground rows y90.
- Registered head-region pixel mismatches: zero after correcting one stray sleeve pixel.
- See validation JSON, Godot log and browser-check screenshot beside this file. Visual acceptance still belongs to the user; technical checks cannot prove subjective polish.

## Movement-speed integration constraint
The existing scene overrides SPEED to 150 pixels/second. This animation has a 36-pixel stride per complete cycle. At 8 FPS its matched movement speed is 48 pixels/second. At 150 pixels/second it would need 25 FPS (0.24-second cycles), which is much faster than the intended relaxed walk. Leaving movement at 150 with playback at 8 causes sliding. This requires movement-speed/cadence tuning during integration; no existing gameplay code or scene was modified.

## Files
- yuki_walk_right_96x96_sheet_v4.png
- yuki_walk_right_v4_1.png through yuki_walk_right_v4_6.png
- yuki_walk_right_v4.tres
- yuki_walk_right_v4_review.html
- yuki_walk_right_v4_parts/ (reusable layers, model edit source, reconstruction source)
- yuki_walk_right_v4_prompt.txt
- yuki_walk_right_v4_validation.json
- yuki_walk_right_v4_godot_validation.log
- yuki_walk_right_v4_browser_check.png

Animation reference reviewed: Animation Mentor, “Tutorial: Animating a Basic Human Walk Cycle”: https://www.animationmentor.com/blog/tutorial-animating-human-walk-cycle/ . Contact, down/weight transfer and passing poses informed the rebuilt key poses. Six frames were retained rather than adding independently drawn intermediates.

