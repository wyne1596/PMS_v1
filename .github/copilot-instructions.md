# Copilot Instructions

## Project Guidelines
- For each Figma screen, use that module's own reference-specific statcard counts/captions and icons; create missing module-specific icons as needed instead of forcing icon consistency across modules, while reusing shared controls where appropriate.
- For Payment, Maintenance, Leasing, and future module UserControls, match the entire Leasing layout consistently—including positions, sizes, styling, and component spacing—while varying only module-specific values such as titles, captions, counts, and icons.
- For the WinForms UI, assign stat-card icons through Visual Studio Properties > Appearance > BackgroundImage. When debugging a single broken card, do not change shared Statcard behavior globally—scope the fix to only that card.
- When correcting a visual implementation, prioritize the attached target screenshot and make a minimal proportional adjustment to the original icon sizing rather than broadly redesigning shared stat-card layout. Update icon assets/values yourself; only adjust icon sizing and placement, and leave icon assignments/content unchanged.
- When reverting a visual change, restore only the specific requested styling adjustment to the original values and preserve later unrelated icon/resource updates unless explicitly asked to revert them too.