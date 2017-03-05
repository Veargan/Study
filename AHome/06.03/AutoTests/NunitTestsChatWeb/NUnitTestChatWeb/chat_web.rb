require 'selenium-webdriver'
require 'test/unit'


class RegChat < Test::Unit::TestCase

  def setup
    @driver1 = Selenium::WebDriver.for :firefox
    @wait = Selenium::WebDriver::Wait.new(:timeout=> 10)
  end

  def test_sing_up
    @driver1.navigate.to 'file:///C:/Users/vista/Desktop/%D0%92%D0%BE%D0%BB%D0%BE%D0%B2%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%B0%D1%8F%20(QA)/DONTSOV_VERSION/ChatRoomsFinal/ChatClient/Client/Web/index.html'
    sleep(1)
    @driver1.find_element(:id, 'login').send_keys 'User111'
    @driver1.find_element(:id, 'password').send_keys '1'
    @driver1.find_element(:id, 'reg').click
    sleep(3)
    newroom_button = @driver1.find_element(:id, 'newroom')
    assert(newroom_button.displayed?)
    assert_equal('file:///C:/Users/vista/Desktop/%D0%92%D0%BE%D0%BB%D0%BE%D0%B2%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%B0%D1%8F%20(QA)/DONTSOV_VERSION/ChatRoomsFinal/ChatClient/Client/Web/index.html', @driver.current_url)
  end

    def test_sign_in
      @driver2.navigate.to 'file:///C:/Users/vista/Desktop/%D0%92%D0%BE%D0%BB%D0%BE%D0%B2%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%B0%D1%8F%20(QA)/DONTSOV_VERSION/ChatRoomsFinal/ChatClient/Client/Web/index.html'
      sleep(1)
      @driver2.find_element(:id, 'login').send_keys 'Ira1'
      @driver2.find_element(:id, 'password').send_keys '1'
      @driver2.find_element(:id, 'auth').click
      sleep(3)
      newroom_button = @driver2.find_element(:id, 'newroom')
      assert(newroom_button.displayed?)
      assert_equal('file:///C:/Users/vista/Desktop/%D0%92%D0%BE%D0%BB%D0%BE%D0%B2%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%B0%D1%8F%20(QA)/DONTSOV_VERSION/ChatRoomsFinal/ChatClient/Client/Web/index.html', @driver.current_url)
    end

    def test_new_room
      @driver2.find_element(:id, 'roomname').send_keys 'Room1'
      @driver2.find_element(:id, 'newroom').click
      sleep(3)
      @driver2.find_element(:value, 'Room1').click
      @driver2.find_element(:id, 'connectroom').click
      sleep(3)
      msg_button = @driver2.find_element(:id, 'sendroommsg')
      assert(msg_button.displayed?)
      assert_equal('file:///C:/Users/vista/Desktop/%D0%92%D0%BE%D0%BB%D0%BE%D0%B2%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%B0%D1%8F%20(QA)/DONTSOV_VERSION/ChatRoomsFinal/ChatClient/Client/Web/index.html', @driver.current_url)
    end

    def test_send_message
      @driver2.find_element(:id, 'roommsg').send_keys 'RubyTest'
      @driver2.find_element(:id, 'sendroommsg').click
      sleep(3)
      expected_text = 'RubyTest'
      actual_text = @driver2.find_element(:id, 'txt_chat').text
      assert_equal(expected_text, actual_text)
      @driver2.find_element(:id, 'exit').click
    end

    def test_answer
      @driver1.find_element(:value, 'Room1').click
      @driver1.find_element(:id, 'connectroom').click
      sleep(3)
      @driver1.find_element(:id, 'roommsg').send_keys '123'
      @driver1.find_element(:id, 'sendroommsg').click
      sleep(3)
      expected_text = 'RubyTest', '123'
      actual_text = @driver2.find_element(:id, 'txt_chat').text
      assert_equal(expected_text, actual_text)
      @driver2.find_element(:id, 'exit').click
    end

    def test_privat_msg
      @driver2.find_element(:id, 'privatemsg').send_keys 'RubyTest'
      @driver2.find_element(:id, 'sendprivatemsg').click
      sleep(3)
      #expected_text = 'RubyTest'
      #actual_text = @driver1.find_element(:id, '').text
      #assert_equal(expected_text, actual_text)
      #@driver2.find_element(:id, 'logout').click
    end

    def test_forgot_password
      @driver3.navigate.to 'file:///C:/Users/vista/Desktop/%D0%92%D0%BE%D0%BB%D0%BE%D0%B2%D0%B5%D0%BB%D1%8C%D1%81%D0%BA%D0%B0%D1%8F%20(QA)/DONTSOV_VERSION/ChatRoomsFinal/ChatClient/Client/Web/index.html'
      sleep(1)
      @driver2.find_element(:id, 'forgotpass').click
      sleep(3)
      @driver2.find_element(:id, 'e-mail').send_keys 'volovelya@gmail.com'
      #@driver2.find_element(:id, '').click
      #sleep(3)
    end
  def teardown
    @driver.quit
  end
end