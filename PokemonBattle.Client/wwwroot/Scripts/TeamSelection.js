function clickPokemonTeamSlot(element, clickedClass) {
    element.classList.toggle(clickedClass);
}

function deselectOtherTeamSlots(pokemonTeamSlotBaseClass, clickedClass) {
    let slots = document.getElementsByClassName(pokemonTeamSlotBaseClass);

    Array.from(slots).forEach(slot => {
        if (slot.classList.contains(clickedClass)) {
            slot.classList.toggle(clickedClass);
        }
    });
}
