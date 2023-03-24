# roblox_idler.py

"""Roblox Idler is an idling tool for Roblox built with Python and PyQT"""

import sys
import keyboard

from PyQt6.QtWidgets import (
    QApplication,
    QMainWindow,
    QWidget,
    QDialog,
    QDialogButtonBox,
    QLineEdit,
    QFormLayout,
    QLabel,
    QPushButton
)

ERROR_MSG = "ERROR: Enter a valid number"
# WINDOW_SIZE = 235

class IdlerWindow(QMainWindow):
    """Roblox Idlers main window"""
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Roblox Idler")
        # self.setFixedSize(WINDOW_SIZE, WINDOW_SIZE)
        self.generalLayout = QFormLayout()
        central_widget = QWidget(self)
        central_widget.setLayout(self.generalLayout)
        self.setCentralWidget(central_widget)
        self._create_input(self.generalLayout)
        self._create_buttons(self.generalLayout)

    def _create_input(self, layout):
        input_field = QLineEdit()
        input_field.setMaxLength(2)
        layout.addRow("How often should be move your avatar?", input_field)

    def _create_buttons(self, layout):  
        layout.addWidget(QPushButton("Start")) 

def main():
    """Idlers main function"""
    idler_app = QApplication([])
    idler_window = IdlerWindow()
    idler_window.show()
    sys.exit(idler_app.exec())

if __name__ == "__main__":
    main()

def validate_input(input = 5):
    if (not isinstance(input, int)):
        return False
    if (input < 1 or input > 19):
        return False
    return True

def run_idler():
    # display dialog box and run the code for the right amount of time
    # start_time = 
    keyboard.wait("1")
    keyboard.write("20")
    keyboard.press("w")
    keyboard.send("a")
    keyboard.send("s")
    keyboard.send("d")
    keyboard.send("space")
