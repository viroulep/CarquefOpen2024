# Assumes "SubsequentRound" is defined

# Clear staff assignments for qualified people to this round
ClearAssignments(
    Persons(CompetingInRound(SubsequentRound())), true, false, Groups(SubsequentRound()))

AssignGroups(SubsequentRound(),
    EveryoneAssignmentSet())
