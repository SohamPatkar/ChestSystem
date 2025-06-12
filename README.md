# Service Locator Pattern (GameService)
Central access point for services like ChestService, EventService, etc.

Promotes decoupling: classes don’t need to know how to construct services.

# Observer Pattern (EventService)
Used to broadcast events like:

"Chest Added"

"Chest Collected"

"Undo Attempted" → e.g., show “Nothing to Undo”

Promotes reactive and extensible UI feedback.

# State Machine (Chest States)
Chests have states like:

LockedState, UnlockingState, CollectedState, etc.

Transitions managed per chest.

Clean encapsulation of chest behavior.

# Command Pattern (ChestService / IUndoAction)
You store command objects on a stack (undoState) for undo functionality.

Implemented IUndoAction or similar interface for Undo().

# Flow 

GameService -> Adding Gems, Subtracting Gems and Creating chests through Chest Service

ChestService -> ChestControllers: 4 types Rare, Legendary, Epic, Common -> ChestView

EventService -> UI



