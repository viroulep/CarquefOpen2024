#include "lib/helpers.cs"
#include "lib/r2-helpers.cs"

AddResults(_444-r2,
  Persons(And((PsychSheetPosition(_444) > 2), (PsychSheetPosition(_444) < 43))))

AssignGroups(_444-r2,
    Concat([AssignmentSet("firstfirst", First444SetCondition(), true)],
    EveryoneAssignmentSet()))
