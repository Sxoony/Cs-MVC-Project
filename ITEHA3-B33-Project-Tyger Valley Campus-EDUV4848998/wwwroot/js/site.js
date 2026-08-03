function getStaffId() {
    const input = document.getElementById('staffIdInput');
    const id = input.value.trim();
    const guidRegex = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/;

    if (!id) {
        alert('Please enter a Staff ID first.');
        return null;
    }
    if (!guidRegex.test(id)) {
        alert('That doesn\'t look like a valid Staff ID (expected format: 8-4-4-4-12 hex characters).');
        return null;
    }
    return id;
}
