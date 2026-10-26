# Café Game — Project Context

Last updated: 2026-10-26. Stage: documentation initialization only.

## 1. Project Overview

Create a small, polished 2D pixel-art café game for a software development portfolio, inspired by Chagall Café from *Persona 3 Reload*. The intended result is a compact game with a cohesive, recognizable café environment and manageable development scope.

The project draws on the original game's atmosphere and visual identity; it does not aim to recreate the entire original game. Gameplay, delivery platform, final title, and completion criteria remain undecided. The project folder is named `Velvet-Cafe`; this does not confirm the game's title.

## 2. Game Design and Visual Direction

**Confirmed direction**

- Use consistent 2D pixel art with cohesive proportions, colors, and presentation.
- Use Chagall Café as the primary reference for furniture, tables, chairs, counter, decorations, and layout.
- Include Yuki, inspired by his appearance in *Persona 3 Reload*, as a café employee.
- Dress Yuki in his café barista/work uniform, not his regular outfit.
- Keep the café compact; avoid excessive detail and unnecessary features.

**Unresolved**

Visual reference images have not yet been supplied. Camera perspective, layout, palette, sprite and tile dimensions, character proportions, animation states, and export specifications are not confirmed. The concept alone is insufficient to produce final assets.

## 3. Technical Stack

Godot is the confirmed game engine. The Godot version, programming language, other development tools, target platform, rendering settings, and asset import requirements remain undecided. Confirm remaining technical choices with the user before implementation.

## 4. Directory Structure

Confirmed project root: `C:\Users\AMD\Desktop\Projects\Velvet Cafe\Velvet-Cafe`

The user confirmed this path on 2026-10-26 and requested that all project work and this document reside here. The current structure is:

```text
Velvet-Cafe/
├── .git/         # Git repository metadata
└── PROJECT.md    # Project context and handoff notes
```

The continuity document has been moved into the confirmed project root at the user's request. Use this directory as the working directory for all future project inspection and authorized development.

No game directory hierarchy or naming conventions have been approved. The following reusable Godot structure is proposed only; no directories or game files have been created. Add folders only when needed. Obtain approval before creating directories, moving files, or reorganizing resources; preserve existing resource references.

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

No individual assets have been requested for creation, generated, approved, or integrated. No asset files are present.

Anticipated asset categories are Yuki in his barista uniform, café furniture, decorations, and environmental elements. These are conceptual needs, not authorization to generate assets or a finalized asset list.

Before each asset task, obtain the user's relevant references and specific instructions. Record its intended use, filename, dimensions, format, and animation requirements when confirmed. Track requested, generated, approved, and integrated stages separately.

## 6. Implementation Status

- **Completed:** Reviewed the initialization brief, created this continuity document, and moved it into the user-confirmed project root. The root contains `.git` and `PROJECT.md`.
- **In progress:** No game development work.
- **Planned but unimplemented:** The overall café game concept; no specific gameplay features are approved.
- **Known issues:** No implementation exists to evaluate.
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

Resume from directory planning: Godot is confirmed, and a reusable directory structure has been proposed but not approved or created. Gameplay scope and visual specifications remain undecided. Missing information includes the Godot version, language, specific visual references, and requirements for the first user-selected task. Ask focused questions only when essential to that task.

## 10. Handoff Notes

- Recent progress: Godot is confirmed. A reusable directory structure is proposed in section 4; approval is pending. Development has not begun.
- Project root: `C:\Users\AMD\Desktop\Projects\Velvet Cafe\Velvet-Cafe`.
- Central document: `C:\Users\AMD\Desktop\Projects\Velvet Cafe\Velvet-Cafe\PROJECT.md`.
- Original brief: `C:\Users\AMD\.codex\attachments\8897885c-f91a-4cd9-8996-d80b7d3920e0\Pasted text.txt`. Essential project instructions are preserved here; future sessions need not rely on the attachment being available.
- Outstanding decisions: Godot version, programming language, remaining tools, target platform, minimum gameplay scope, perspective, asset specifications, layout, and directory proposal approval.
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
