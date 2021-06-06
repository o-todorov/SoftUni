function ConstructionCrew(worker){
    if(worker.dizziness){
        worker.levelOfHydrated += worker.weight * worker.experience * 0.1;
        worker.dizziness = false;
    }
    return worker;
}

ConstructionCrew(
    { weight: 80,
        experience: 1,
        levelOfHydrated: 0,
        dizziness: true }
)