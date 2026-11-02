# Café Game — Project Context

Last updated: 2026-10-27. Stage: approved pose and shoulders; steady-head breathing/blink v3 produced and Godot resource validated.

**2026-11-02 — Resolution prototypes:** User paused right-walk refinement to compare 64x64 and 32x32 idle-down versions. Created direct nearest-neighbor reductions of all 23 canonical 96x96 cells under `draft/yuki_resolution_prototypes/`, with rest PNGs, sheets, SpriteFrames resources and a native/enlarged animated comparison. Palette and transparency are sampled directly from the source; no redesign. Timing follows the current source resource (5.14 seconds). These are unretouched resolution studies; reduced facial detail is expected. No resolution has been selected. Original assets and gameplay scenes remain unchanged.

## Current Asset Decision and Latest Progress (2026-10-27)

**2026-10-30 — Walk-right v6:** User requested sharper chin and removal of the apparent extra legs. Chin tapered with four local pixel changes; all model pixels outside the chin remain unchanged from v5. Static trouser pixels removed from the torso layer. Thigh/shin textures now sample one isolated canonical idle leg instead of the overlapping profile legs; each articulated leg has one compact shoe. Six 96×96 frames at 8 FPS; three live Godot loops passed. Files: `draft/yuki_walk_right_96x96_sheet_v6.png`, `yuki_walk_right_v6.tres`, `yuki_walk_right_v6_review.html`, `yuki_walk_right_v6_preview.png`, and validation JSON/log. User visual approval remains pending; original assets and gameplay scenes unchanged.

**2026-10-30 — Walk-right v5:** User approved v4 hair but requested the original idle's narrower relaxed eye and neutral poker-face mouth, plus correction of backward-leaning movement. This overrides the earlier smiling/cheerful face request. V5 retains all model pixels outside eight eye/mouth edits, sampled from canonical idle colors. Head moves forward 3px without changing shape; shoulder-to-hip alignment and trailing-foot recovery are revised, arm swing reduced. Six 96×96 frames at 8 FPS. Native/enlarged playback checked; three live Godot loops passed. See `draft/yuki_walk_right_v5_notes.md`, the APNG comparison and interactive review. Approval remains pending; original idle is still authoritative, and no gameplay scene changed.

**Walk-right v4:** Replaced independently drawn v3 poses with a fixed profile model and reusable pixel parts. See `draft/yuki_walk_right_v4_notes.md`. Hair uses exact canonical hair colors with matched highlight distribution. Registered head/face pixels match across all six frames (zero differences after compensating for the 0/1px weight shift). Six 96×96 frames, 576×96 transparent sheet, 8 FPS, 0.75-second loop. Browser playback checked at native resolution and enlarged, including repeated 6-to-1 transitions. Godot 4.7.2 ran three live AnimatedSprite2D loops in an isolated test project. Visual approval remains pending. Scene movement is currently 150px/s; this stride matches 48px/s at 8 FPS and would require 25 FPS at 150px/s. Movement speed/cadence needs tuning before integration; existing gameplay code and scenes remain unchanged. The v3 walk remains superseded and must not be used as canonical reference.

Right-walk rebuild candidate v3: `draft/yuki_walk_right_96x96_sheet_v3.png`, six 96×96 transparent cells in a 576×96 sheet. Source edit uses the canonical sheet's first frame, verified pixel-identical to `draft/yuki_idle_down_blink_v3_rest.png`, never the rejected concepts. Built-in image generation supplied directional poses; nearest-neighbor packing and exact canonical RGB palette mapping prepared the cells. Verified zero output colors outside the source palette and binary transparency. Original occupied height is 86px; walking poses occupy 84–86px, with bottom anchor y90. Native-resolution comparison: `draft/yuki_walk_right_v3_comparison.png`; animated side-by-side review: `draft/yuki_walk_right_v3_review.html`. Resource: `draft/yuki_walk_right_v3.tres`, six-frame `walk_right` loop at 8 FPS. Visual identity and motion remain unapproved; matching the palette and dimensions does not prove identical character geometry. Resource has not been validated in Godot; no existing scenes or original sprites changed. Generated frame geometry is not pixel-identical to the original.

**Permanent visual identity requirement:** Read `AGENTS.md` before any asset work. The user explicitly designated `scenes/characters/yuki/sprites/yuki_idle_down_blink_96x96_sheet_v3.png` as Yuki's canonical reference. Its original pixels, exact palette, proportions, clothing and rendering are authoritative. Previously generated walk-right concepts failed identity consistency and are rejected as production assets or design references. They require rebuilding from the canonical sprite, not merely cosmetic cleanup. Apply this original-first workflow to every game asset and verify native-resolution state transitions before completion. This supersedes earlier descriptions of the walk drafts as usable concepts and earlier source-of-truth paths where those conflict.

Walking direction requirement (2026-10-27): Yuki's head and face must look straight along his movement direction, in side profile, never toward the viewer. Right-walking frames face screen right; future left-walking frames must face screen left. Preserve his asymmetric hairstyle rather than assuming a simple horizontal flip is sufficient. Generated review draft: `draft/yuki_walk_right_profile_v2.png`. This remains an unapproved concept, not a validated 96×96 game asset; background/glow, proportions, alternating stride and frame registration still need production cleanup. No scenes changed.

The user approved the hand-at-side pose and shoulder motion in v2, but requested a better-fitting head animation. Following reference research, the user chose one longer animation: steady head, existing shoulder breathing, and an occasional blink. No head bob or hair motion is included in v3.

Created `scenes/characters/yuki/sprites/yuki_idle_down_blink_96x96_sheet_v3.png` (2208×96 RGBA; 23 cells, each 96×96) and `scenes/characters/yuki/yuki_idle_down_blink_v3.tres` (Godot SpriteFrames resource, animation `idle_down`). Four unique drawings—rest, raised shoulders, half-closed eye, closed eye—are reused across 23 timed entries. The loop lasts 4.8 seconds. Breathing repeats every 960 ms. The blink begins at 4.08 seconds and lasts 200 ms: half-close 60 ms, closed 80 ms, half-open 60 ms. Original v1 and v2 assets remain unchanged. The approved v2 first pose is pixel-identical to v3's first frame.

Load the `.tres` into an AnimatedSprite2D's Sprite Frames property to preserve the prepared timing. The resource uses 25 FPS with per-frame duration multipliers (6 for normal holds, 1.5/2/1.5 for blinking, and 1 for the remaining open hold). A plain uniform-FPS import of the PNG will not reproduce the blink timing. The PNG layout is Horizontal=23, Vertical=1, no margins. No existing scene was changed.

Verification: original file hashes unchanged; head pixels fixed except the 3×2 eye region; body below the head matches the approved rest/lift poses; feet and lower body remain identical; binary transparency; sheet slicing checked; decoded GIF duration is 4800 ms. Godot 4.7.2 loaded the resource successfully in an isolated check project, with all 23 textures at 96×96, looping enabled, and a computed 4.8-second duration. Visual poses reviewed; in-game appearance and user approval remain pending.

Review files in `draft/`: `yuki_idle_down_blink_v3_preview.gif`, lossless animated `yuki_idle_down_blink_v3_preview.png`, `yuki_idle_down_blink_v3_poses.png`, `yuki_idle_down_blink_v3_validation.json`, `yuki_idle_down_blink_v3_godot_validation.log`, `yuki_idle_down_blink_v3_generated_eye_reference.png`, and `yuki_idle_down_blink_v3_prompt.txt`. Built-in image generation supplied the closed-eye reference; only registered eye detail was applied to the original sprite, then the longer timeline was assembled.

## Previous Revision — Hand-at-Side v2 (2026-10-27)

The approved 96×96 `scenes/characters/yuki/sprites/yuki_idle_down_1.png` remains unchanged. It is the design source of truth. Earlier frame sizes are historical. The user rejected the previous cloth-shading-only idle and supplied a 0.96-second animation reference plus a relaxed hand-at-side reference. The new standing requirement applies to idle in every facing direction: anatomical left hand rests alongside the hip, elbow gently bent, with the other arm relaxed. Only down-facing frames were requested and created here.

Created `scenes/characters/yuki/sprites/yuki_idle_down_side_v2_1.png` through `_4.png` and `yuki_idle_down_side_96x96_sheet_v2.png`. Each frame is 96×96 RGBA; the sheet is 384×96, four cells left-to-right without padding. New first pose retains the original pixels except the requested left-arm region (viewer right). The original first frame and earlier animation files remain intact.

Motion follows the reference's upper-body rise and settle with anchored feet. Frames: rest, shoulder/upper-chest lift, peak with rigid one-pixel head lift, return through the shoulder-lift pose. Frames 2 and 4 deliberately repeat. No head or body scaling and no independent frame regeneration. The new hand stays at the hip. Playback: 240 ms per frame (approximately 4.167 FPS), 960 ms per loop; 4 FPS gives a slightly slower one-second loop.

Creation: built-in image_gen edited the arm pose, followed by pixel registration and compositing into the approved base. The arm was matched to the approved palette. Head, face, outfit, other arm and lower body of the new resting pose otherwise retain original pixels. Validation confirms unchanged original file hash, identical lower body from row 63 in every frame, exact registered head pixels, binary alpha, and exact sheet slicing. The side-by-side frames were visually inspected. In-engine playback and user approval remain pending. No scene or gameplay code was changed.

Review files in `draft/`: `yuki_idle_down_side_v2_preview.gif`, lossless animated `yuki_idle_down_side_v2_preview.png`, `yuki_idle_down_side_v2_frames.png`, `yuki_idle_down_side_v2_pose_comparison.png`, `yuki_idle_down_side_v2_validation.json`, `yuki_idle_down_side_v2_generated_pose.png`, and `yuki_idle_down_side_v2_prompt.txt`. The enlarged previews are for review, not game import. Godot sheet settings: Horizontal=4, Vertical=1, all four cells in order, looping. Source references: `C:/Users/AMD/Downloads/Video/zcvybmmt2ytc1.mp4` and `C:/Users/AMD/AppData/Local/Temp/codex-clipboard-d1470f77-c058-4c31-9a96-bc54bfc5bfb1.png`.

Previous 96×96 sheet v1 only moved interior cloth details and was rejected for inadequate animation. Its files remain preserved. The new reference-directed pose and controlled translations supersede the earlier restriction that only interior shading could move.

## 1. Project Overview

Create a small, polished 2D pixel-art café game for a software development portfolio, inspired by Chagall Café from *Persona 3 Reload*. The intended result is a compact game with a cohesive, recognizable café environment and manageable development scope.

The project draws on the original game's atmosphere and visual identity; it does not aim to recreate the entire original game. Confirmed gameplay: a top-down game where Yuki moves around the café, takes customers' orders at their tables, and serves them. Detailed mechanics, delivery platform, final title, and completion criteria remain undecided. The project folder is named `Velvet-Cafe`; this does not confirm the game's title.

## 2. Game Design and Visual Direction

**Confirmed direction**

- Use consistent 2D pixel art with cohesive proportions, colors, and presentation.
- Use Chagall Café as the primary reference for furniture, tables, chairs, counter, decorations, and layout.
- Include Yuki, inspired by his appearance in *Persona 3 Reload*, as a café employee.
- Preserve Yuki's original slim appearance and recognizable character design.
- His barista outfit consists of his normal underlying clothes with an apron, not a completely redesigned outfit. Supplied café references show a light collared shirt with rolled sleeves and a brown bib apron; the combat reference supplies character identity rather than a requirement to include combat equipment.
- Keep the café compact; avoid excessive detail and unnecessary features.

**Unresolved**

Five references have been supplied: one full character illustration, three café/barista views, and one Blasphemous pixel-art comparison. Blasphemous is a guide to proportions and detail, not a confirmed source of exact sprite dimensions or a perspective template.

Confirmed current frame size: 96×96 pixels. Preserve the approved relaxed face, covered eye, outfit, and slim silhouette. Preserve anatomy, head dimensions, palette, and foot anchors. The latest direction keeps the head fixed and preserves shoulder motion, adding an occasional blink; all idle directions must use the relaxed hand-at-side pose. Use equal-cell transparent PNG spritesheets for Godot SpriteFrames.

The user likes the detailed idle draft and has approved retaining its resolution and appearance. Earlier 48–54-pixel body targets and 64×64 frame proposals are obsolete. Preserve the current design while improving animation; do not redesign its proportions without user instruction.

## 3. Technical Stack

Godot is the confirmed game engine. The existing project.godot declares Godot 4.7 features and the Mobile renderer; this does not independently verify the installed editor version. Programming language and target platform remain undecided. The user will import animation through Godot SpriteFrames using the spritesheet method. Confirm remaining technical choices with the user before implementation.

## 4. Directory Structure

Confirmed project root: `C:\Users\AMD\Desktop\Projects\Velvet Cafe\Velvet-Cafe`

The actual project has since been initialized and organized by the user. Relevant verified paths:

```text
Velvet-Cafe/
├── project.godot
├── PROJECT.md
├── .git/
├── .godot/                         # Generated editor data
├── draft/
│   ├── yuki_idle_down_v1.png
│   └── yuki_idle_down_v2_preview.gif
├── scenes/characters/yuki/
│   ├── yuki.tscn                  # Existing Node2D scene; unchanged by this revision
│   └── sprites/
│       ├── yuki_idle_down_v1.png
│       └── yuki_idle_down_v2.png
└── shared/
```

This is a relevant subset, not a complete listing. Use the confirmed project root for all work. Preserve the user's current organization; the earlier general structure below remains a reference proposal for future additions.

**Proposed structure**

```text
Velvet-Cafe/
├── project.godot       # Godot project settings, created by the editor
├── PROJECT.md          # Project context and decisions
├── .gitignore          # Version-control exclusions
├── scenes/             # Scenes grouped by game feature
│   ├── main/           # Entry scene and startup flow
│   ├── characters/     # One folder per character
│   ├── levels/         # Playable locations and maps
│   ├── props/          # Reusable world objects
│   └── ui/             # Menus, HUD, and other interface scenes
├── shared/             # Resources genuinely reused across features
│   ├── audio/
│   ├── fonts/
│   ├── themes/
│   └── tilesets/
├── autoload/           # Only approved project-wide singleton services
├── addons/             # Third-party plugins and libraries
├── source_art/         # Editable art masters; contains .gdignore
├── references/         # Visual references; contains .gdignore
└── docs/               # Extra documentation; contains .gdignore
```

Proposed conventions: keep each feature's scene, attached scripts, and exclusive runtime assets together (for example, `scenes/characters/yuki/yuki.tscn` and `yuki.png`). Move resources into `shared/` only when multiple features use them. Use `snake_case` for directories and files, `PascalCase` for nodes, and `PascalCase.cs` for C# scripts if C# is selected. Keep `PROJECT.md` as the established documentation filename. An empty `.gdignore` excludes a folder from Godot's resource import and loading, not from Git; never put runtime resources in ignored folders. Prefer moving imported resources through Godot's FileSystem dock and verify references afterward.

Basis: [Godot project organization guidance](https://docs.godotengine.org/en/stable/tutorials/best_practices/project_organization.html). This layout is a project recommendation, not an engine requirement.

## 5. Asset Inventory

**Confirmed Yuki animation plan**

| Animation | Frames | Starting playback speed |
| --- | --- | --- |
| Idle | 4 per facing direction | 3–4 FPS |
| Walk up (TOP, away from camera) | 6 | 8–10 FPS |
| Walk down | 6 | 8–10 FPS |
| Walk right | 6 | 8–10 FPS |
| Walk left | 6 | 8–10 FPS |

- Four facing directions: up, down, right, and left. Idle retains the last movement direction.
- Total: 16 idle frames and 24 walking frames, or 40 frames across eight directional animations. Every current Yuki frame is 96×96 pixels; earlier 64×64 and 495×793 specifications are superseded.
- Idle uses a restrained upper-body rise and settle with a relaxed hand at the hip. Head and hair remain fixed except for the visible-eye blink; feet remain planted. Never scale anatomy to simulate breathing.
- Walking uses a six-frame loop. Tune starting playback speeds to movement speed and visual testing in-game.
- Left-facing body poses may reuse horizontally mirrored right-facing poses; correct the hair to preserve the same anatomically covered eye. Horizontal mirroring does not mean reversing animation frame order.
- Production order: standing base first, then down-facing walking, then expand the set. This plan supersedes earlier proposals for one- or two-frame idle and four-frame walking.
- Status: specifications recorded; first down-facing idle design draft generated. No production animation frames approved or integrated.

**Idle revision v2:** `scenes/characters/yuki/sprites/yuki_idle_down_v2.png`. Transparent RGBA PNG, exactly 1980×793 pixels, four 495×793 cells in one row. Built with user-authorized pixel-level processing from one v1 pose, preserving detail and colors; no regeneration or redesign. Sequence: relaxed, partial inhale, peak inhale, partial exhale. Shoulders lift up to 8 pixels and the chest expands locally; head, covered eye, legs, and feet remain pixel-identical across frames. Horizontal centering is fixed. Frames 2 and 4 intentionally reuse the intermediate pose. Alpha was cleaned to binary transparency. Preview: `draft/yuki_idle_down_v2_preview.gif`, four frames at 250 ms each (4 FPS), looping on a neutral background. The GIF is for review only; import the PNG into Godot.

Verification: exact sheet and cell dimensions checked, fixed lower-body/head pixels checked, upper-body changes checked, and sheet visually inspected. Godot playback has not been tested; the existing scene is unchanged. User approval of this revision is pending. Import with Horizontal=4, Vertical=1, all four cells left-to-right, 4 FPS, loop enabled, no cell spacing or outer margin. Future six-frame sheets at this size will be 2970×793 pixels.

**Idle draft v1 (historical):** now located at `scenes/characters/yuki/sprites/yuki_idle_down_v1.png`, generated with the built-in image tool using the approved standing concept as reference. Prompt requested four down-facing breathing poses, fixed feet, the same covered eye, and a transparent 256×64 strip. Actual output is 1983×793 pixels in 32-bit ARGB format, with four visible poses; it is not divisible into four equal integer-width cells. The user subsequently approved keeping its detailed design and using 495×793 cells. Visual review also finds a larger head and shorter proportions than the approved concept. The user approved its appearance but rejected its sliding animation. Preserve its design; correct alignment and breathing rather than reducing resolution. Other directions have not been generated.

The user approved the standing concept sheet's appearance and proportions, describing it as exactly what they imagined. The sheet contains front, three-quarter, and back standing studies. Saved as `yuki_standing_concept.png` in the project root to preserve the approved visual reference. This is concept approval only: no production sprite or animation has been verified or integrated.

Preview: `C:\Users\AMD\.codex\generated_images\01a17a4f-7a87-7be1-9728-d09588b06b3a\exec-606b68d4-8779-4fcc-9e1e-c6ce69338ac3.png`. Generated using the built-in image tool. Visual review: the sheet explores slim proportions, blue asymmetric hair, light rolled-sleeve shirt, and brown apron. It is a detailed concept illustration, not a verified 64×64 sprite; the camera is close to eye level and still needs adaptation for top-down gameplay. Back apron construction is inferred, not established by the supplied references. The user has approved the visual design; 495×793 production frames now supersede the earlier 64×64 plan; playback speeds are starting values to tune in-game.

Reference images supplied for discussion are currently attached from temporary paths, not copied into the project:

- `C:\Users\AMD\AppData\Local\Temp\codex-clipboard-49024a88-eb79-4572-ba34-c38dfd7a39a5.png`: Yuki character illustration.
- `C:\Users\AMD\AppData\Local\Temp\codex-clipboard-c586c884-7012-4629-bb9f-2791e92253a0.png`: close café/barista view.
- `C:\Users\AMD\AppData\Local\Temp\codex-clipboard-469d9c8c-5ec7-494b-a809-f73b5bff5fa6.png`: café serving pose.
- `C:\Users\AMD\AppData\Local\Temp\codex-clipboard-3ae9e70d-2ad6-41c8-a0b2-17664d86825d.png`: frontal café/barista view.
- `C:\Users\AMD\AppData\Local\Temp\codex-clipboard-88a7e22e-3671-459a-9441-6ab486414f25.png`: Blasphemous pixel-art comparison.

Temporary reference paths may not survive future sessions. These references are not generated or approved game assets.

Anticipated asset categories are Yuki in his barista uniform, café furniture, decorations, and environmental elements. These are conceptual needs, not authorization to generate assets or a finalized asset list.

Before each asset task, obtain the user's relevant references and specific instructions. Record its intended use, filename, dimensions, format, and animation requirements when confirmed. Track requested, generated, approved, and integrated stages separately.

## 6. Implementation Status

- **Completed:** Documentation updated; user-created Godot project inspected; idle revision v2 and looping review GIF produced and structurally verified.
- **In progress:** Review of the four-frame 96×96 down-facing idle; no game code or scene edits.
- **Planned but unimplemented:** Top-down movement around the café, taking orders at tables, and serving customers. Implementation has not been requested.
- **Known issues:** V1 slides and is not evenly divisible into four cells. V2 fixes cell alignment and adds local breathing; in-engine playback and user acceptance remain unverified.
- **Pending inputs:** User direction, technical stack decisions, and task-specific visual references and specifications.

## 7. Development Roadmap

The following milestones are **proposals only**, not approved tasks or authorization to begin work.

| Priority | Proposed milestone | Dependencies | Completion criteria |
| --- | --- | --- | --- |
| 1 | Define the minimum game scope and technical stack | User decisions | Agree on the core experience, target platform, engine, language, and relevant versions. |
| 2 | Establish visual and organizational conventions | Supplied references and selected engine | Approve perspective, dimensions, palette, asset requirements, and a suitable directory plan. |
| 3 | Create and approve essential assets incrementally | Explicit request and references for each asset | Review each requested asset for visual consistency and engine suitability; record approval separately. |
| 4 | Implement and integrate the agreed game scope | Explicit coding requests and relevant approved assets | Verify requested behavior in the chosen engine and record integration status. |
| 5 | Polish and prepare the portfolio presentation | Agreed scope implemented | Verify the agreed completion criteria and prepare the user-selected presentation or delivery format. |

Essential work should support the compact café experience. Additional animations, decorations, gameplay systems, and presentation extras remain optional proposals requiring user agreement. No optional features are currently committed.

## 8. Confirmed Decisions and Constraints

- The assistant supports game development, pixel-art creation, coding, and project organization collaboratively.
- Follow the Pixel Art Production Guidelines in section 11 whenever creating, editing, or reviewing pixel art assets.
- Do not generate pixel art until the user supplies relevant references and explicitly requests the individual asset.
- Do not write game code or implement features automatically. Discussion of an idea is not an implementation request.
- Provide coding explanations, reviews, debugging, or implementation when requested.
- Understand the existing project before proposing structural changes. Obtain approval before applying them.
- Do not silently change requirements, choose unresolved specifications, or expand scope.
- Initialization authorizes only `PROJECT.md`; no game code, gameplay, assets, extra directories, or reorganization.
- No specific technical or design approaches have been rejected beyond these scope constraints.

**Documentation maintenance**

Update this document when meaningful progress or decisions occur, preferably changing only relevant sections. Record verified facts as completed work. Clearly label assumptions and proposals. Keep design discussion separate from implementation, asset approval separate from generation and integration, and existing structure separate from proposed changes. Preserve consequential decisions and verified paths without copying conversation transcripts or recording every minor exchange.

Actual project files remain the source of truth for implementation details; this document supplies continuity and context.

## 9. Next Steps

Wait for the user's next instruction. Do not start a roadmap milestone automatically.

Resume by reviewing the steady-head breathing/blink v3 preview and SpriteFrames resource. Preserve the original approved first frame. Confirm Godot playback and user acceptance before extending the same hand-at-side pose to other directions.

## 10. Handoff Notes

- Recent progress: Original approved base preserved; reference-directed hand-at-side v2 idle frames and 384×96 sheet created. Lower body and rigid head geometry verified. Animation awaits review.
- Project root: `C:\Users\AMD\Desktop\Projects\Velvet Cafe\Velvet-Cafe`.
- Central document: `C:\Users\AMD\Desktop\Projects\Velvet Cafe\Velvet-Cafe\PROJECT.md`.
- Original brief: `C:\Users\AMD\.codex\attachments\8897885c-f91a-4cd9-8996-d80b7d3920e0\Pasted text.txt`. Essential project instructions are preserved here; future sessions need not rely on the attachment being available.
- Outstanding decisions: Godot version, programming language, remaining tools, target platform, detailed gameplay scope, precise top-down viewing angle, sprite specifications, layout, and directory proposal approval.
- At handoff, read this document and inspect relevant current files before claiming implementation status. Use newly supplied user instructions and references to guide the next authorized task.

## 11. Pixel Art Production Guidelines

The AI must follow these practices whenever creating, editing, or reviewing pixel art assets, including characters, items, props, tilesets, maps, animations, effects, and UI elements.

### 1. Maintain a Consistent Art Style

- Follow the project's established art direction, references, color palette, shading, outlines, proportions, and level of detail.
- Treat existing approved assets as the source of truth for visual consistency.
- Do not introduce a new style without approval.

### 2. Respect Technical Constraints

- Follow the project's defined sprite dimensions, tile sizes, color palette, transparency requirements, and grid conventions.
- Maintain consistent pivot points, anchor positions, and alignment where applicable.
- Preserve crisp pixel edges. Avoid unintended antialiasing, blur, and subpixel artifacts.
- Use nearest-neighbor scaling when resizing pixel art.

### 3. Follow Pixel Art Fundamentals

- Prioritize recognizable silhouettes and readability at the intended in-game size.
- Use intentional pixel clusters instead of random, noisy details.
- Apply consistent outlines, shading, contrast, and lighting direction.
- Avoid unnecessary details that reduce clarity.

### 4. Respect Asset-Specific Requirements

- **Characters:** Maintain consistent proportions, alignment, silhouettes, and animation frames.
- **Items and props:** Prioritize recognizable shapes and consistent icon dimensions.
- **Tilesets and maps:** Ensure tiles connect correctly, respect the grid, and distinguish walkable areas from obstacles.
- **Animations and effects:** Prevent unintended jitter and maintain consistent timing, alignment, and readability.
- **UI elements:** Keep icons, borders, spacing, and visual complexity consistent.

### 5. Use References and AI Generation Responsibly

- Review provided references before creating an asset.
- Do not generate assets prematurely. Wait for the user to provide the relevant requirements and references.
- Generate assets incrementally rather than creating large batches without validation.
- Treat AI-generated images as drafts until their technical quality and consistency have been verified.
- Never invent missing project requirements when clarification is necessary.

### 6. Validate Every Asset

Before considering an asset complete, verify:

- Correct dimensions, transparency, and file format.
- Clean pixel edges and absence of unintended artifacts.
- Consistency with the approved art style and existing assets.
- Readability at native game resolution.
- Correct alignment, grid placement, and animation consistency where applicable.
- Successful integration into the game when relevant.

### 7. Organize and Preserve Assets

- Use descriptive, consistent filenames and an organized folder structure.
- Keep source files, exported assets, references, and animation data organized.
- Preserve approved assets and avoid overwriting them without permission.
- Update documentation when new conventions are established.

### 8. Follow an Incremental Workflow

1. Understand the asset's purpose and requirements.
2. Review relevant references and existing assets.
3. Identify applicable technical constraints.
4. Create or modify the asset only when instructed.
5. Validate the result against the requirements.
6. Present the result for review and incorporate feedback.
7. Mark the asset as approved only after user confirmation.

**Core principle:** Visual consistency, technical correctness, and in-game readability take priority over unnecessary detail. The AI must act as a disciplined pixel-art production assistant, following the project's established rules rather than making independent assumptions about its art direction.




