-- init.sql

-- Create a new user (if not already existing)
CREATE USER IF NOT EXISTS 'newuser'@'%' IDENTIFIED BY 'TransferMate1';

-- Grant privileges to the new user
GRANT ALL PRIVILEGES ON *.* TO 'newuser'@'%';

-- Apply the changes
FLUSH PRIVILEGES;