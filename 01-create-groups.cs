Define("CreateGroupsInRoom",
    CreateGroups({1, Round}, {2, Number}, "Salle principale",
                 RoundStartTime({1, Round}), RoundEndTime({1, Round})))

# Create groups for Saturday

CreateGroupsInRoom(_555-r1, 2)
CreateGroupsInRoom(_444bf-r1, 1)
CreateGroupsInRoom(_pyram-r1, 3)
CreateGroupsInRoom(_555-r2, 3)

CreateGroupsInRoom(_333bf-r1, 2)
CreateGroupsInRoom(_clock-r1, 2)
CreateGroupsInRoom(_333oh-r1, 2)
CreateGroupsInRoom(_444-r1, 3)
CreateGroupsInRoom(_minx-r1, 2)
CreateGroupsInRoom(_pyram-r2, 1)
CreateGroupsInRoom(_333oh-r2, 1)


# Create groups for Sunday

CreateGroupsInRoom(_222-r1, 3)
CreateGroupsInRoom(_333-r1, 4)
CreateGroupsInRoom(_444-r2, 2)
CreateGroupsInRoom(_333-r2, 3)
CreateGroupsInRoom(_333bf-r2, 1)
CreateGroupsInRoom(_222-r2, 1)
CreateGroupsInRoom(_pyram-r3, 1)
CreateGroupsInRoom(_444-r3, 1)
CreateGroupsInRoom(_333-r3, 1)
