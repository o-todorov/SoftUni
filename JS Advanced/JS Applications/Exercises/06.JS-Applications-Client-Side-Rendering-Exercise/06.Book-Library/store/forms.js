export let editForm = (actions) => ({
    id: 'edit-form',
    caption: 'Edit book',
    submitText: 'Save',
    submitHandler: actions.editBook,
    cancelHandler: actions.cancelEdit
})

export let addForm = (actions) => ({
    id: 'add-form',
    caption: 'Add book',
    submitText: 'Submit',
    submitHandler: actions.createBook,
})