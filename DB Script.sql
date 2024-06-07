
-- Create table for roles
CREATE TABLE roles (
    id SERIAL PRIMARY KEY,
    name VARCHAR(50) NOT NULL UNIQUE,
    priority VARCHAR(20) NOT NULL
);


-- Create table for employees
CREATE TABLE employees (
    id SERIAL PRIMARY KEY,
    employee_id VARCHAR(20) NOT NULL UNIQUE,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    mobile_no VARCHAR(15) NOT NULL,
    date_of_joining DATE NOT NULL,
    project_manager_id INT,
    employee_status VARCHAR(20) NOT NULL,
    skill_sets TEXT,
    role_id INT NOT NULL,
    FOREIGN KEY (role_id) REFERENCES roles(id),
    FOREIGN KEY (project_manager_id) REFERENCES employees(id)
);
-- Create table for clients
CREATE TABLE clients (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    location VARCHAR(100) NOT NULL,
    reference_name VARCHAR(100) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


-- Create table for projects
CREATE TABLE projects (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL UNIQUE,
    description TEXT,
    start_date DATE NOT NULL,
    end_date DATE,
    project_reference_id VARCHAR(50) NOT NULL UNIQUE,
    client_id INT NOT NULL,
    team_members_count INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (client_id) REFERENCES clients(id) ON DELETE CASCADE
);

-- Create table to link employees to projects
CREATE TABLE employee_projects (
    employee_id INT NOT NULL,
    project_id INT NOT NULL,
    base_price DECIMAL(10, 2) NOT NULL,
    price_type VARCHAR(10) NOT NULL CHECK (price_type IN ('hourly', 'monthly')),
    currency VARCHAR(10) NOT NULL,
    PRIMARY KEY (employee_id, project_id),
    FOREIGN KEY (employee_id) REFERENCES employees(id),
    FOREIGN KEY (project_id) REFERENCES projects(id)
);

-- Create table for timesheets
CREATE TABLE timesheets (
    id SERIAL PRIMARY KEY,
    employee_id INT NOT NULL,
    project_id INT NOT NULL,
    date DATE NOT NULL,
    hours_worked DECIMAL(5, 2) NOT NULL CHECK (hours_worked >= 0 AND hours_worked <= 24),
    description TEXT,
    approved_by_id INT,
    FOREIGN KEY (employee_id) REFERENCES employees(id),
    FOREIGN KEY (project_id) REFERENCES projects(id),
    FOREIGN KEY (approved_by_id) REFERENCES employees(id)
);