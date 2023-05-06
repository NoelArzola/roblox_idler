import keyboard
import time

keep_alive = True
ERROR_MESSAGE = '*BANG BANG BANG!!* F.B.I! OPEN UP'

class Idler():

    def __init__(self):
        super().__init__()
        self.user_input = self.grab_input()

    def validate_input(self, interval):
        if (interval < 1 or interval > 19):
            print*(ERROR_MESSAGE)
            return False
        return True

    def grab_input(self):
        user_value = input('enter a NUMBER from 1-19')

        if (user_value in ['', ' ', '  ',]): # empty, 1 space, 2 spaces,
            user_value = 5 # they didint give a number, set value to 5
            print('Using the default value of 5! sorry for the inconveniece...')

        try:
            user_value = int(user_value)
        except:
            print(ERROR_MESSAGE)
            return

        return user_value
    
    def play_game(self, user_input):
        keyboard.send('w')
        time.sleep(1)
        keyboard.send('a')
        time.sleep(1)
        keyboard.send('s')
        time.sleep(1)
        keyboard.send('d')
        time.sleep(1)
        keyboard.send('space')
        time.sleep(60 * user_input)

    def stop_playing(self):
        global keep_alive
        keep_alive = False
        print('Q was pressed, Closing...\nTo quit immediately hit "ctrl/cmd+c"')

    def run_idler(self):
        if (self.validate_input(self.user_input)):
            print('Starting idler in a minute. please switch to a game.')
            global keep_alive
            time.sleep(60)
            keyboard.add_hotkey('q', lambda: self.stop_playing())
            print('Idler is running, Press Q anytime to exit')
            while (keep_alive):
                self.play_game(self.user_input)            

idler = Idler()
idler.run_idler()