# Permanent project rule: sprite consistency and visual identity

Original sprites supplied by the user are canonical. Animate or extend the existing asset; never regenerate an existing character from imagination or treat it as a new design. This applies to every character, object, environment asset, animation, and object state. Visual consistency takes priority over creative reinterpretation.

## Required invariants
- Preserve face, hairstyle, hair volume, eyes, skin tone, and distinguishing features.
- Preserve head-to-body ratio, torso dimensions, limb thickness, silhouette, and overall scale.
- Preserve outfit construction, seams, accessories, apron shape, and footwear.
- Reuse the original sprite's exact palette, not approximate colors.
- Match pixel density, outline thickness, shading technique, and detail.
- Preserve frame dimensions, ground position, anchors, and consistent character scale where appropriate. Natural pose changes must not become scale changes.
- Newly visible surfaces must logically extend the established design, never redesign it.
- Reuse existing pixel clusters, shapes, and design elements whenever possible.

## Mandatory workflow
1. Locate and inspect the canonical original before any sprite creation or modification.
2. Identify its proportions, exact palette, outlines, shading, and distinguishing details.
3. Use that sprite as the foundation, modifying only what the requested direction or motion requires.
4. Compare every new frame with the original at native pixel resolution.
5. Check state transitions for identity, scale, palette, and alignment discontinuities.
6. Correct inconsistencies before declaring completion. A beautiful but inconsistent sprite fails.
7. If the original cannot be accessed, request it; do not invent its appearance.

## Yuki
Canonical reference explicitly supplied on 2026-10-27:
C:/Users/AMD/Desktop/Projects/Velvet Cafe/Velvet-Cafe/scenes/characters/yuki/sprites/yuki_idle_down_blink_96x96_sheet_v3.png

The sheet is 2208×96 with 23 cells of 96×96. Use its actual pixel data as the authority, not enlarged previews or generated concepts.
Latest expression direction (2026-10-30): retain the idle-down sprite's relaxed narrow eye and neutral poker-face mouth. Do not add a smile, angry brow or wide-eyed expression. User approved the v4 right-facing hair; preserve its colors, highlights and silhouette while correcting the face and movement. Persona 3 Reload screenshots are posture references only; they do not replace the canonical pixel sprite.
Yuki's head and face must look along movement direction: right profile when moving right, left profile when moving left, never toward the viewer in those directional animations. Preserve asymmetric design details when constructing either direction.

The generated walking concepts, including draft/yuki_walk_right_concept_v1.png and draft/yuki_walk_right_profile_v2.png, failed visual identity consistency. They are rejected as production assets and must never replace or become canonical references. The unrelated auburn-haired animation reference is not Yuki. Preserve existing original assets; do not overwrite them without authorization.

