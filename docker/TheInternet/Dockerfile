FROM ruby:2.6.5
RUN git clone https://github.com/tnypxl/the-internet.git app
WORKDIR /app
RUN gem install bundler
RUN bundle install
EXPOSE 5000
CMD ["bundle", "exec", "rackup", "--host", "0.0.0.0", "-p", "5000"]