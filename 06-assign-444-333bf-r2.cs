#include "lib/helpers.cs"
#include "lib/r2-helpers.cs"

#AddResults(_444-r2,
  #Persons(And((PsychSheetPosition(_444) > 2), (PsychSheetPosition(_444) < 43))))
#AddResults(_333bf-r2,
  #Persons(And((PsychSheetPosition(_333bf) > 2), (PsychSheetPosition(_333bf) < 20))))

# Hippolyte has been assigned to both 4x4 groups, just remove him from one
ClearAssignments([2008MORE02], true, false,
    Filter(Groups(_444-r2), (GroupNumber() == 2)))

AssignGroups(_444-r2,
    Concat([AssignmentSet("firstfirst", First444SetCondition(), true)],
    EveryoneAssignmentSet()))

Define("SubsequentRound", _333bf-r2)

#include "lib/basic-assign-subsequent.cs"
