// Store chart instances to destroy and recreate them when data changes
window.chartInstances = {};

// Render a pie chart
window.renderPieChart = (canvasId, labels, data, backgroundColors) => {
    const ctx = document.getElementById(canvasId);

    // Destroy existing chart if it exists
    if (window.chartInstances[canvasId]) {
        window.chartInstances[canvasId].destroy();
    }

    window.chartInstances[canvasId] = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                data: data,
                backgroundColor: backgroundColors,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'bottom'
                },
                tooltip: {
                    callbacks: {
                        label: function(context) {
                            const total = context.dataset.data.reduce((sum, val) => sum + val, 0);
                            const value = context.raw;
                            const percentage = Math.round((value / total) * 100);
                            return `${context.label}: ${value} (${percentage}%)`;
                        }
                    }
                }
            }
        }
    });
};

// Render a bar chart
window.renderBarChart = (canvasId, labels, data, backgroundColors) => {
    const ctx = document.getElementById(canvasId);

    // Destroy existing chart if it exists
    if (window.chartInstances[canvasId]) {
        window.chartInstances[canvasId].destroy();
    }

    window.chartInstances[canvasId] = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Number of Blogs',
                data: data,
                backgroundColor: backgroundColors,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        precision: 0
                    }
                }
            },
            plugins: {
                legend: {
                    display: false
                }
            }
        }
    });
};

// Render a line chart
window.renderLineChart = (canvasId, labels, data, borderColor) => {
    const ctx = document.getElementById(canvasId);

    // Destroy existing chart if it exists
    if (window.chartInstances[canvasId]) {
        window.chartInstances[canvasId].destroy();
    }

    window.chartInstances[canvasId] = new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: canvasId.includes('Sales') ? 'Units Sold' : 'Revenue ($)',
                data: data,
                borderColor: borderColor,
                backgroundColor: `${borderColor}33`, // Add transparency
                borderWidth: 2,
                fill: true,
                tension: 0.1
            }]
        },
        options: {
            responsive: true,
            scales: {
                y: {
                    beginAtZero: true,
                    ticks: {
                        callback: function(value) {
                            if (canvasId.includes('Revenue')) {
                                return '$' + value.toLocaleString();
                            }
                            return value;
                        }
                    }
                }
            }
        }
    });
};